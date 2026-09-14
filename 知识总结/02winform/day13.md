# day13｜递归函数 + 打字游戏 + Control.Invoke跨线程 + Settings本地配置 + DLL动态链接库 完整汇总总结

> 整合三份文档：Invoke.md、setting.md、动态链接库.md + 原有day13递归、打字游戏。

## 一、递归函数

### 核心概念

递归：**函数内部调用自己**。

> ⚠️必须设置**终止（基线）条件**，无终止条件或者递归深度过大会发生 `StackOverflowException` 栈溢出崩溃。 执行流程：向下递归拆解问题；碰到终止条件，逐层回溯计算结果。

#### 示例1：阶和 5+4+3+2+1

```
public static int Digui(int num)
{
    if (num == 1) return 1; //终止条件
    return num + Digui(num - 1);
}
```

#### 示例2：斐波那契数列 `1 1 2 3 5 8 …`

```
public static int Feibo(int num)
{
    if(num ==1) return 1;
    if(num ==2) return 1;
    return Feibo(num-1)+Feibo(num-2);
}
```

#### 示例3：交替级数 `1‑1/2+1/3‑1/4…±1/100`

```
public static double GetSum(double num)
{
    if(num ==1) return 1;
    double val = num%2 ==1 ? 1/num : -1/num;
    return val + GetSum(num-1);
}
```

> 适用场景：文件夹递归遍历、树形节点遍历；注意：递归性能开销高于循环。

## 二、WinForm打字下落游戏（综合实战）

### 核心知识点

1. `System.Windows.Forms.Timer` 定时器做动画。
2. 代码动态new Label控件，`panel.Controls.Add()`添加到容器。
3. `this.KeyPreview=true`：窗体优先接收键盘，不受子控件焦点拦截。
4. `KeyUp`键盘松开事件；`Enum.TryParse<Keys>()`文本转按键枚举。
5. `List<Dictionary<string,dynamic>>`集合保存【字母Label + 对应Timer】，批量管理多组动态对象。

- V1版本：仅单个字母下落。
- V2版本：多个字母同时下落；命中字母计分；任意字母触底全部定时器停止，GameOver。

### 易错点

1. 定时器事件重复绑定，重启游戏前`-=`解绑旧事件。
2. 游戏结束要Remove动态控件、Stop全部Timer，防止内存残留。
3. 不设置`KeyPreview`，焦点在输入框，窗体捕获不到按键。

### 工业上位机拓展

- 递归遍历目录、树形设备节点；
- 动态生成点位/缺陷UI控件；
- `KeyPreview`实现软件全局快捷键。

## 三、Invoke （委托Invoke / 控件.Invoke跨线程更新UI）

### 3.1 委托自身的Invoke

1. 委托本质编译器生成类，继承`MulticastDelegate`；自带`Invoke / BeginInvoke / EndInvoke`。
2. `del.Invoke(args)`等价直接写`del(args)`，是语法糖；签名和委托完全匹配。
3. **多播委托Invoke**：按顺序执行全部绑定方法；有返回值只取最后一个方法返回值；中间抛出异常，后面方法不再执行。

```
public delegate void LogHandler(string msg);
LogHandler log = Console.WriteLine;
log += s=>File.AppendAllText("log.txt",s+"\n");
log.Invoke("测试消息");
```

### 3.2 控件.Invoke 跨线程更新UI⭐WinForm高频

> WinForm控件具备**线程亲和性**：控件只能在创建它的UI主线程访问；子线程禁止直接操作控件。

1. `control.Invoke(Delegate)`：**同步封送到UI线程执行**；子线程等待UI执行完毕再继续。
2. `control.BeginInvoke()`异步封送，不等待UI执行完成。
3. `InvokeRequired`：bool；`true`代表当前不是UI线程，需要调用Invoke。

> 注意版本差异

- .NET Framework 默认开启跨线程检查，直接操作UI抛异常。
- .NET Core/.NET5‑8 默认关闭检查，不会抛异常，但业务依然不推荐直接子线程操作UI。

```
//手动开启和Framework一样的校验
Control.CheckForIllegalCrossThreadCalls = true;
```

标准安全写法模板：

```
if(label1.InvokeRequired)
{
    label1.Invoke(new Action(()=>{
        label1.Text = "子线程更新UI";
    }));
}
else
{
    label1.Text = "主线程直接赋值";
}
```

> 工业视觉：相机采集、串口/网络子线程收到数据，通过Invoke更新界面状态、缺陷计数。

## 四、Settings WinForm内置本地配置

> 用途：保存软件配置参数，窗口大小、记住账号、连接参数，程序重启还能读取。

### 两种Scope作用域

| 作用域      | 读写权限     | 存储位置    | 使用场景                                   |
| ----------- | ------------ | ----------- | ------------------------------------------ |
| Application | 只读，不能写 | exe.config  | 数据库地址、全局公共参数，所有用户一致     |
| User        | 可读可写     | user.config | 窗口大小、记住密码、主题，当前用户私有配置 |

### 核心对象：`Properties.Settings.Default`

1. **读取配置**

```
string user = Properties.Settings.Default.Username;
bool rem = Properties.Settings.Default.RememberMe;
```

1. **赋值（只在内存，不落地）**

```
Properties.Settings.Default.Username = txtUser.Text;
```

1. **Save() 持久化写入硬盘**

```
Properties.Settings.Default.Save();
```

1. **Reset()恢复默认值，清空用户修改**

```
Properties.Settings.Default.Reset();
```

> 易错：赋值之后必须调用`Save()`，否则程序关闭数据丢失。

## 五、DLL动态链接库

### 5.1 .NET托管DLL（类库ClassLibrary）

1. DLL：Dynamic‑Link Library，后缀`.dll`；代码打包成独立零件仓库。
2. 优点：代码复用、模块化分工、单独更新dll，不用重新发布整个exe。
3. 创建：新建【类库】项目；类、方法必须标记`public`，外部项目才可以访问。
4. 生成：项目右键【生成】，bin/Debug/Release产出`.dll`文件。

两种引用方式：

1. **项目引用（同解决方案开发推荐）**：添加项目引用；修改类库代码重新生成，主程序自动同步。
2. **浏览文件引用**：导入现成第三方dll文件。

调用：`using 命名空间;` 然后new类实例调用方法。

### 5.2 `[DllImport]`平台调用（调用C/C++原生非托管dll）

> 作用：调用Windows系统API、C++写的原生硬件SDK库。 ❗注意：**不能用来引用.NET托管DLL，.NET dll要添加项目引用+using**。

语法模板

```
using System.Runtime.InteropServices;

[DllImport("kernel32.dll")]
public static extern bool AllocConsole();
```

- `extern`：方法实现在外部dll，只做声明，没有函数体。
- `static`：直接类调用，不用实例。
- 签名必须和C/C++原生函数严格匹配，否则崩溃。

示例：WinForm弹出黑色控制台窗口

```
[DllImport("kernel32.dll")]
public static extern bool AllocConsole();
static void Main()
{
    AllocConsole();
    ApplicationConfiguration.Initialize();
    Application.Run(new Form1());
}
```

> 工业视觉场景：DllImport调用相机、板卡C++原生SDK；业务逻辑封装成托管类库DLL，主WinForm界面调用。

## 📝综合面试问答

**Q1：InvokeRequired作用，子线程为什么不能直接操作WinForm控件？**

> A：InvokeRequired判断当前执行线程是否UI线程；WinForm控件线程亲和性，控件属于创建它的UI线程；子线程直接操作会出现异常/未知bug，使用Control.Invoke封送委托到UI线程执行。

**Q2：Settings赋值之后为什么数据重启丢失？**

> A：赋值仅修改内存对象，必须调用`Save()`，数据才写入硬盘user.config。

**Q3：DllImport和添加项目引用dll有什么区别？**

> A：DllImport用于调用C/C++原生非托管DLL；.NET托管类库dll，要添加项目引用，using命名空间，new实例使用，不能DllImport。

**Q4：递归什么时候栈溢出？**

> A：没有终止条件无限递归；递归调用深度太大，占用调用栈，报StackOverflowException。

> 如果你需要，我可以把 day01‑day13 全部WinForm+C#基础合并成一份超级背诵复习文档。