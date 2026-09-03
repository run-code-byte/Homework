# day07｜C# WinForm 多线程 Thread‑ThreadPool‑Task‑async/await、多媒体、MySQL数据库 结构化总结

> 承接day06用户控件与控件通信；核心：进程线程概念、原生Thread、线程池ThreadPool、Task任务、async/await异步、WMP音视频播放、MySQL数据库基础操作。

## 1、上节回顾

1. 窗体：`Show() / Hide() / ShowDialog() / Close() / Application.Exit()`
2. UserControl用户控件：封装重复UI布局逻辑，生成解决方案后工具箱才可见。
3. 控件通信
   - 父子通信：父直接访问子控件公开属性、方法传参。
   - 子→父：子控件定义自定义`Action`事件，`?.Invoke()`触发向外抛数据；父绑定事件接收。
   - 非父子跨窗体：**单例消息中间人模式**，字典存储暗号+回调函数实现解耦通信。

## 2、进程与线程基础

### 概念

- **进程**：操作系统给应用分配的整套资源（内存、权限）；进程之间互相隔离，任务管理器看到的条目就是进程。

- 线程

  ：进程内部CPU调度的执行流；

  一个进程可以拥有多条线程，共享进程内存资源

  。

  > WinForm程序默认只有一条**UI主线程**；耗时操作放在主线程会造成界面卡死，需要新开子线程执行耗时逻辑。

比喻： 进程=一整张餐桌资源；线程=餐桌上面干活的服务员；一个服务员卡住不影响其他服务员干活。

## 3、原生 Thread 类

> 手动创建操作系统线程，开销大，频繁大量创建性能差。

| API                       | 说明                                                         |
| ------------------------- | ------------------------------------------------------------ |
| `Thread.CurrentThread`    | 拿到当前正在执行的线程对象                                   |
| `线程.ManagedThreadId`    | 线程ID（int）                                                |
| `线程.Name`               | 读写线程名称                                                 |
| `new Thread(方法)`        | 创建线程对象；带参数函数参数必须是`object`                   |
| `Start(object? state)`    | 启动线程，可传入参数                                         |
| `Thread.Sleep(ms)`        | 让当前线程休眠阻塞指定毫秒                                   |
| `Join()` / `Join(超时ms)` | **阻塞当前线程，等待该线程执行完毕**                         |
| `ThreadState`             | 线程状态枚举：Unstarted未启动、Running运行、WaitSleepJoin阻塞、Stopped结束 |
| `IsBackground`            | 是否后台线程；前台线程不结束，进程不会退出；后台进程退出直接被强行终止 |
| `Priority`                | 线程优先级 Lowest‑BelowNormal‑Normal‑AboveNormal‑Highest，仅获得CPU时间片概率更高 |
| `IsAlive`                 | bool，线程是否还在运行未结束                                 |

> ⚠️注意：**子线程禁止直接操作WinForm UI控件**，会报跨线程操作无效异常。

## 4、线程池 ThreadPool

1. 问题：频繁new Thread反复创建销毁线程开销大。
2. 线程池：预先存放一批线程，任务来了复用线程，任务完成线程归还池，不销毁。
   - **Worker工作线程**：用于CPU密集计算
   - **IOCP IO线程**：专门处理文件、网络、数据库IO阻塞任务
3. 核心API

```
//提交任务到线程池
ThreadPool.QueueUserWorkItem(state=>{ /*业务*/ }, 参数对象);

//获取、设置线程池最大最小线程（不建议随意修改默认值）
ThreadPool.GetMinThreads(out int minWork,out int minIO);
ThreadPool.GetMaxThreads(out int maxWork,out int maxIO);
```

## 5、Task 任务（推荐，底层基于线程池）

> Task关注**任务**，不用关心底层线程；支持返回值、等待、连续任务、批量任务、取消。

### 5‑1 创建启动

```
//方式1：直接运行
Task.Run(()=>{ });
//方式2：new实例，需要手动Start()
Task t = new Task(()=>{ });
t.Start();

//带返回结果 Task<T>
Task<int> t = Task.Run(()=>{ return 100; });
```

### 5‑2 等待、获取结果

1. `t.Result`：获取返回值，**会阻塞当前线程！UI主线程慎用，界面卡死**。
2. `t.Wait()`：阻塞等待任务完成，等价Thread.Join，UI线程慎用。

### 5‑3 批量任务

1. `Task.WhenAll(tasks)`：监视全部任务完成；全部结束才完成。
2. `Task.WhenAny(tasks)`：任意一个任务完成就结束。

### 5‑4 连续任务 ContinueWith

上一个任务结束自动执行后续任务；可以指定执行条件：

- `OnlyOnRanToCompletion`：只有正常完成才执行
- `OnlyOnFaulted`：仅任务异常才执行，做异常捕获
- `OnlyOnCanceled`：仅任务被取消才执行

```
Task.Run(()=>{
    //前置业务
}).ContinueWith(prev=>{
    //后置业务，prev拿到上一个Task对象
},TaskContinuationOptions.OnlyOnRanToCompletion);
```

### 5‑5 Task状态枚举

`Created`创建未启动 / `WaitingToRun`等待调度 / `Running`运行 / `RanToCompletion`正常结束 / `Faulted`发生异常 / `Canceled`被取消。

### 5‑6 任务取消 CancellationTokenSource

```
CancellationTokenSource cts = new CancellationTokenSource();
Task.Run(()=>{
    //业务
},cts.Token);
cts.Cancel(); //请求取消任务
```

## 6、async / await 异步语法糖⭐重点

### 规则

1. `async`修饰方法；`await`只能写在async方法内部。
2. async函数返回值只能：`void` / `Task` / `Task<T>`。
3. `await task`：**不会阻塞UI线程**；暂停当前方法，交出线程；任务完成后恢复继续执行。
4. 对比：`.Result` / `.Wait()` 是阻塞；`await`是非阻塞等待。

```
private async void button1_Click(object sender,EventArgs e)
{
    //不会卡死界面
    await Task.Delay(3000);
    label1.Text = "执行完毕";
}
```

> 工业上位机：IO、网络、数据库操作大量使用async‑await，防止UI卡死。

## 7、多媒体播放

### ① AxWindowsMediaPlayer COM组件

1. 添加工具箱：工具箱右键选择项 → COM组件 → 勾选Windows Media Player。
2. 常用成员

```
axWindowsMediaPlayer1.URL = @"xxx.mp4"; //媒体路径
axWindowsMediaPlayer1.settings.autoStart = false; //关闭自动播放

axWindowsMediaPlayer1.Ctlcontrols.play();
axWindowsMediaPlayer1.Ctlcontrols.pause();
axWindowsMediaPlayer1.Ctlcontrols.stop();
axWindowsMediaPlayer1.settings.volume = 70; //0‑100音量
axWindowsMediaPlayer1.uiMode = "none"; //仅画面，无控制栏
```

1. 事件：

- `PlayStateChange`：播放状态切换（停止、播放、暂停、播放结束），循环播放写在播放结束case。
- `PositionChange`：播放进度改变。
- `ErrorEvent`：播放出错。

### ② SoundPlayer（原生.NET，仅wav音频）

```
SoundPlayer sp = new SoundPlayer("./xxx.wav");
sp.Play();      //异步后台播放
sp.PlaySync();  //阻塞播放
sp.Stop();
```

## 8、MySQL数据库操作（MySqlConnector第三方NuGet包）

### 核心对象

1. `MySqlConnection`：数据库连接；**using自动释放关闭连接**。
2. `MySqlCommand`：封装SQL语句；支持参数化`AddWithValue`，防SQL注入。
3. `MySqlDataAdapter`：适配器，填充`DataTable`。
4. `MySqlDataReader`：逐条读取结果流。

### 连接字符串

```
string connStr = "server=127.0.0.1;port=3306;database=库名;uid=root;pwd=密码;charset=utf8";
```

### 常用方法

| 方法                   | 用途                          |
| ---------------------- | ----------------------------- |
| `Open() / OpenAsync()` | 打开数据库连接                |
| `ExecuteNonQuery()`    | 增删改，返回受影响行数        |
| `ExecuteScalar()`      | 取第一行第一列，count聚合统计 |
| `ExecuteReader()`      | 返回Reader逐条读取数据        |

> ✨安全重点：使用`Cmd.Parameters.AddWithValue("@参数",值)`参数化查询，**禁止字符串拼接SQL，防止注入攻击**。

示例骨架：

```
using(MySqlConnection conn = new MySqlConnection(connStr))
{
    conn.Open();
    string sql = "select * from user where id=@id";
    using(MySqlCommand cmd = new MySqlCommand(sql,conn))
    {
        cmd.Parameters.AddWithValue("@id",1);
        //执行查询/增删改
    }
}
```

## 9、易错点

1. WinForm **子线程不能直接访问UI控件**，会抛跨线程异常。
2. `Thread`手动创建线程开销大，大量任务优先使用`Task/线程池`。
3. Task的`.Result`、`.Wait()`会阻塞UI线程，窗体界面卡死；优先`await`。
4. `async void`仅用于事件回调，业务方法尽量返回`Task`方便异常捕获。
5. MySQL连接必须`using`，自动释放，避免数据库连接泄露。
6. SQL禁止字符串拼接用户输入；必须参数化`AddWithValue`，防止SQL注入。

## 10、工业视觉上位机拓展

1. 相机采集、图片保存、MES网络请求、数据库查询全部放到子线程/Task，`async‑await`保证界面不卡死。
2. 后台持续硬件状态巡检使用后台线程/Task。
3. WMP做检测视频回放。
4. MySQL存储缺陷记录、产品检测报表；参数化SQL防止注入，using管理数据库连接。

## 📝面试问答

**Q1：Thread、ThreadPool、Task区别？😃**

> A： Thread：手动创建操作系统线程，开销大，频繁创建性能差。 ThreadPool线程池：复用已有线程，减少创建销毁开销，但是不方便获取返回值，不方便批量等待。 Task：底层基于线程池；支持返回值、批量等待WhenAll/WhenAny、连续任务ContinueWith、任务取消；C#推荐优先使用Task。

**Q2：Wait() / .Result 和 await核心区别？🤔**

> A：`Wait()` / `.Result`会**阻塞当前调用线程**，UI线程调用直接卡死界面；`await`是非阻塞等待，交出线程，不会卡死界面，等待完成恢复执行。

**Q3：async‑await中async void和async Task区别？**

> A：`async void`一般只用于UI事件回调，无法捕获异常；业务逻辑尽量返回`Task`，可以做异常捕获、等待。

**Q4：操作MySQL，为什么要用AddWithValue参数化，不直接拼接SQL字符串？**

> A：防止SQL注入攻击；同时自动处理数据类型、引号转义。

**Q5：前台线程与后台线程区别？**

> A：前台线程全部结束，进程才会退出；后台线程，主进程退出会被系统直接强行终止。

> 工业视觉补充：所有耗时IO、硬件操作不要阻塞UI主线程；优先Task+async‑await；数据库连接using释放，参数化防注入。

