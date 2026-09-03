# day14｜命名空间namespace、struct结构体、async/await异步、枚举enum、HttpClient网络请求、泛型、项目发布知识总结

## 1、所学知识清单

### ① 上节回顾

- 抽象类`abstract`、静态类`static class`、密封类`sealed`
- 接口`interface`、`this`关键字、属性`get/set`访问器

### ② 命名空间 namespace

1. 作用：给类、接口划分隔离区域，**解决不同文件同名类冲突**。
2. 定义语法

```
namespace 命名空间名
{
    // 类、接口、结构体等
}
```

1. 完整限定名称调用：`Vision.Device.Camera cam = new Vision.Device.Camera();`
2. `using 命名空间;` 导入命名空间，简化书写，不用写完整长路径。

### ③ 结构体 struct

1. `struct`定义结构体；**结构体是值类型，class类是引用类型**。

2. 结构体**不能继承类，也不能被类继承**，可以实现接口。

3. 可以拥有字段、属性、方法；实例化语法和类相似。

   > 工业视觉常用场景：坐标点Point、矩形、点云数据，轻量级小数据优先struct。

```
struct Point
{
    public int X;
    public int Y;
    public double GetDistance()
    {
        return Math.Sqrt(X*X + Y*Y);
    }
}
```

### ④ 异步 async / await

1. 问题背景：同步执行耗时IO（读文件、网络请求），主线程阻塞，程序卡死。

2. 关键字

   - `async`：标记方法为异步方法，返回值一般为`Task / Task<T>`；Main入口也可以标记`static async Task Main()`。
   - `await`：**等待异步任务完成拿到结果，再继续向下执行**。

3. ```
   Stopwatch
   ```

   高精度计时器，统计代码执行耗时。

   - `Stopwatch.StartNew()`直接创建并启动；
   - `.ElapsedMilliseconds`获取毫秒耗时；`.Elapsed`得到TimeSpan。

4. 组合用法：

   - `Task.WhenAll(t1,t2,t3)`：**并行等待多个任务全部完成**。
   - 文件异步API：`File.ReadAllTextAsync()`。

> 注意：await只能写在被async修饰的方法内部。

### ⑤ 枚举 enum

1. 作用：限定取值范围，避免传入非法数字；底层本质存储整数。
2. 默认第一个成员值从0开始；可以手动指定数值，后面成员自动自增。
3. 枚举**不能写在方法内部**；可以强制和int互相转换。

```
enum Gender
{
    Man,    //0
    Woman   //1
}
```

### ⑥ HttpClient 网络请求

> 需要引入命名空间`using System.Net.Http;`

1. 创建对象：`HttpClient client = new HttpClient();`
2. 请求方法
   - Get：`GetAsync(url)`
   - Post：`PostAsync()`，支持表单、JSON、文件上传
   - Put / Delete
3. 读取响应：`response.Content.ReadAsStringAsync()`读字符串；`GetByteArrayAsync()`获取字节（下载图片/文件）。
4. 请求数据类型
   - 表单：`FormUrlEncodedContent`
   - JSON：`StringContent`，设置`application/json`
   - 文件上传：`MultipartFormDataContent`
5. 请求头设置
   - 全局头：`client.DefaultRequestHeaders`
   - 单次请求头（推荐）：`HttpRequestMessage request`对象上设置Headers，不污染全局。
6. 返回的JSON字符串，搭配`JsonSerializer`反序列化为C#对象。

### ⑦ 泛型 Generic

1. 核心：**类型参数化**，定义的时候不写死具体类型，调用时才指定实际类型。
2. 泛型方法：`static void ShowListData<T>(List<T> list)`，`<T>`代表占位类型参数。
3. 泛型类：`class Dictionary<TKey,TValue>`，集合大量使用泛型。
4. 优势：编译做类型检查，不用object装箱拆箱，类型安全、性能高。

### ⑧ 项目发布（控制台程序）

1. 右键项目 → 发布 → 目标选【文件夹】
2. 部署模式：**独立**，自带.NET运行库，发给普通Windows用户直接运行。
3. 目标运行时：`win‑x64`
4. 可选配置：生成单个exe文件；ReadyToRun加快启动速度；
5. 配置选择`Release`发行模式（去掉调试信息，代码优化）；发布得到exe可执行文件。

## 2、易错点

1. 命名冲突：不同namespace下同名类，不using就必须写完整限定名。
2. struct结构体是**值类型**，赋值拷贝完整副本，和class引用类型行为不一样。
3. `await`只能在`async`方法里面写；async方法如果没有await会变成同步执行。
4. 枚举不能定义在函数方法体内；枚举转int要用强制类型转换。
5. HttpClient不要频繁new实例；频繁创建会造成套接字资源耗尽，尽量复用对象。
6. 泛型T是编译期占位，运行确定实际类型；泛型方法调用可以省略`<T>`编译器自动推断。
7. 发布的时候区分Debug调试版 / Release发行版；独立部署自带运行库，对方电脑不需要安装.NET。

## 3、拓展（工业视觉上位机场景）

1. 命名空间：项目分层，`Vision.Device`设备层、`Vision.Business`业务层、`Vision.Utils`工具层，管理大量类，防止类名冲突。
2. struct：像素点Point、ROI矩形、检测结果点位，轻量小数据用结构体。
3. async/await：网络请求、读写大图像文件、MES接口通信；防止UI界面卡死。
4. enum：设备状态、产品OK/NG、相机触发模式，限定业务状态取值，避免非法数字。
5. HttpClient：和MES、WebAPI交互，上传检测结果、下载配置文件、下载图像。
6. 泛型：`List<T>`、`Dictionary<TKey,TValue>`，整个上位机集合大量依赖泛型。
7. 发布：把写好的控制台上位机程序打包独立exe，交付产线现场使用。

## 4、面试重点

1. struct结构体和class类的区别？

   > struct是值类型，栈存储，赋值拷贝副本；class是引用类型，栈存地址，堆存对象；struct不能被继承。

2. async和await作用？Task.WhenAll干什么？

   > async标记异步方法；await等待异步任务完成；WhenAll并行等待多个任务全部结束，提高IO耗时操作效率。

3. enum枚举底层是什么？有什么好处？

   > 底层int整数；限制取值范围，增加代码可读性，避免传入非法数字。

4. HttpClient使用注意事项？

   > 尽量复用HttpClient实例，不要循环频繁new；区分全局请求头和单次请求头；支持GET/POST、JSON、表单、文件上传下载。

5. 什么是泛型，泛型好处？

   > 类型参数化，定义不写死类型，调用指定；编译类型安全，避免object装箱拆箱，性能好；集合List、Dictionary大量使用泛型。

6. 控制台项目发布，独立部署是什么意思？Release和Debug区别？

   > 独立部署打包自带.NET运行环境，目标机器不用装框架；Release发行版做代码优化，移除调试信息；Debug带调试信息，开发调试使用。

> 工业视觉补充：
>
> - 设备状态、触发模式大量使用enum；
> - 坐标点、ROI使用struct结构体；
> - MES接口通信全部async/await异步调用；
> - 项目分层靠namespace划分模块；
> - 最终程序独立发布exe给到产线现场。

