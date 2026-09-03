# day15｜控制台综合实战：车辆租还管理系统 结构化总结

> 项目定位：C#面向对象综合实战，控制台菜单交互，JSON本地文件持久化存储数据。 项目分层：**实体Model层、业务Manager管理层、Program入口交互层**。

## 1、项目整体架构

| 分层          | 作用                                           | 文件                                                    | 核心类                                      |
| ------------- | ---------------------------------------------- | ------------------------------------------------------- | ------------------------------------------- |
| Model实体层   | 纯粹数据载体，映射JSON，主键只读，防止外部篡改 | `ProjectClass.cs`                                       | `Car`车辆、`User`客户、`RentReturn`租还记录 |
| Manager业务层 | 封装业务逻辑、JSON读写、数据增删改查           | `CarManager.cs`、`UserManager.cs`、`RentReturnClass.cs` | 车辆管理、客户管理、租还记录管理            |
| 交互入口层    | 控制台菜单、接收用户输入、调用业务方法         | `Program.cs`                                            | Program主程序                               |

### 业务功能清单

1. **车辆管理**：新增车辆、查询全部车辆、按ID查单台、查询空闲车辆；租车时修改车辆状态。
2. **客户管理**：新增客户（手机号正则校验）、查询全部客户、按ID查询客户；提供方法仅校验客户是否存在。
3. **租还记录管理**：租车生成记录；还车计算租赁时长、计算租金；查看全部租还记录。

## 2、核心知识点

1. **面向对象**：类、构造函数；只读属性`{get;}`保护主键；实体只负责存数据，业务逻辑放到Manager类。
2. System.Text.Json序列化持久化
   - 配置项：`WriteIndented`美化输出；`UnsafeRelaxedJsonEscaping`中文不转义；`AllowTrailingCommas`允许末尾逗号。
   - 标准流程：判断文件存在 → 读取文本 → 反序列化得到`List<实体>` → 内存完成业务修改 → 序列化 → 覆盖写回文件。
3. **集合高级方法**：`Find()`查找第一条、`FindAll()`批量过滤、`Exists()`判断是否存在。
4. **元组**：方法返回多个结果 `(string 提示信息, bool 是否成功)`。
5. **正则表达式**：手机号完整匹配校验。
6. **时间处理**：`DateTime`获取当前时间；两个时间相减得到`TimeSpan`；`TotalHours`获取总小时，计算租车费用。
7. IO文件操作：`File.Exists`、`File.ReadAllText`、`File.WriteAllText`。
8. 控制台架构：`while`循环菜单 + `switch`分支分发业务。

## 3、实体类核心定义（节选）

```
//车辆实体
internal class Car
{
    public int Id { get; }
    public string Card { get; }
    public string Type { get; set; }
    public bool Status { get; set; } // true空闲，false已出租
    public double Price { get; set; }
    //构造函数给只读主键赋值
    public Car(int Id, string Card, string Type, bool Status, double Price)
    {
        this.Id = Id;
        this.Card = Card;
        this.Type = Type;
        this.Status = Status;
        this.Price = Price;
    }
}
//User客户、RentReturn租还记录结构同理，构造初始化只读Id等字段
```

> 设计要点：Id、身份证等主键设置只读`{get;}`，只能在构造函数赋值，外部不能随意修改。

## 4、业务层核心方法（只贴代表性核心方法）

### 4.1 CarManager 车辆管理

```
// 租车：修改车辆状态，元组返回提示与执行结果
public (string, bool) UpdateStatus(int id)
{
    if (!File.Exists(Path)) return ("暂无车辆！！！", false);
    string jsonStr = File.ReadAllText(Path);
    List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
    Car carObj = cars.Find(item => item.Id == id);
    if (carObj == null) return ("没有对应ID的车辆！！！", false);
    if (!carObj.Status) return ("该车辆已被租出！！！", false);

    carObj.Status = false;
    string json = JsonSerializer.Serialize(cars, JsonOpt);
    File.WriteAllText(Path, json);
    return ("租车成功！！！", true);
}
```

### 4.2 UserManager 客户管理

```
//新增客户，正则校验手机号
public void Add()
{
    Console.WriteLine("请输入客户姓名：");
    string userName = Console.ReadLine();
    Console.WriteLine("请输入身份证号：");
    string userCardId = Console.ReadLine();
    Console.WriteLine("请输入性别：");
    string gender = Console.ReadLine();
    Console.WriteLine("请输入手机号：");
    string telNum = Console.ReadLine();
    Console.WriteLine("请输入座右铭：");
    string motto = Console.ReadLine();

    //手机号正则完整校验
    if (!Regex.IsMatch(telNum,@"^1\d{10}$"))
    {
        Console.WriteLine("输入手机格式错误！！！");
        return;
    }
    //读取json，判重，自动生成ID，写回文件……
}

//供租车业务调用：只判断客户ID是否存在，返回布尔
public bool SearchOneById(int id)
{
    if (!File.Exists(Path)) return false;
    string jsonStr = File.ReadAllText(Path);
    List<User> list = JsonSerializer.Deserialize<List<User>>(jsonStr);
    return list.Find(item => item.Id == id) != null;
}
```

### 4.3 RentReturnClass 租还业务

```
///还车核心逻辑：计算租赁时长与租金
public void ReturnCar()
{
    Console.WriteLine("请输入租车记录ID: ");
    int id = int.Parse(Console.ReadLine());
    if (!File.Exists(Path)){ Console.WriteLine("没有租车信息！！！"); return; }

    string jsonStr = File.ReadAllText(Path);
    List<RentReturn> rrList = JsonSerializer.Deserialize<List<RentReturn>>(jsonStr);
    RentReturn rrObj = rrList.Find(item => item.Id == id);

    if(rrObj == null) { Console.WriteLine("租车记录ID有误！！！"); return; }
    if(rrObj.ReturnTime != "") { Console.WriteLine("该车辆已还！！！"); return; }

    CarManager CM = new CarManager();
    double price = CM.UpAndGetInfo(rrObj.CarId);
    //时间差计算租金
    TimeSpan diff = DateTime.Now - DateTime.Parse(rrObj.RentTime);
    double payMoney = (double)diff.TotalHours * price;

    rrObj.PayMoney = payMoney;
    rrObj.ReturnTime = DateTime.Now.ToString();
    string jsonrrStr = JsonSerializer.Serialize(rrList, JsonOpt);
    File.WriteAllText(this.Path, jsonrrStr);
    Console.WriteLine("***还车成功***");
}
```

## 5、主程序 Program 核心逻辑

```
static void Main(string[] args)
{
    string num = "";
    CarManager CM = new CarManager();
    UserManager UM = new UserManager();
    RentReturnClass RRC = new RentReturnClass();

    while (num != "0")
    {
        Tips(); //打印菜单
        num = Console.ReadLine();
        switch (num)
        {
            case "1": /*新增车辆*/ break;
            case "2": CM.SearchAll(); break;
            case "8": RRC.RentCar(); break;
            case "9": RRC.ReturnCar(); break;
            case "0": Console.WriteLine("退出系统"); break;
            default: Console.WriteLine("输入编号有误"); break;
        }
    }
}
static void Tips()
{
    //打印操作菜单
}
```

## 6、关键业务流程

### ✅租车流程

1. 用户输入车辆ID、客户ID；
2. 调用`SearchOneById()`校验客户是否存在；不存在直接返回；
3. 调用`CarManager.UpdateStatus()`：校验车辆存在、车辆状态空闲；把车辆状态改为【已出租】；
4. 读取租还记录JSON，自动生成记录ID，租车时间=当前时间，归还时间为空，费用0；写入文件。

### ✅还车流程

1. 用户输入租还记录ID；读取租还记录文件；
2. Find查找记录，校验记录存在；校验还车时间为空（未归还）；
3. 调用`CarManager.UpAndGetInfo()`：车辆状态改回空闲，获取时租单价；
4. `TimeSpan diff = DateTime.Now - 租车时间`；总小时 × 单价得到应付金额；
5. 回填`ReturnTime`归还时间、`PayMoney`金额；集合序列化写回json。

## 7、易错点

1. JSON序列化要求实体属性为`public`；只读`{get;}`属性可以正常反序列化。
2. 修改集合内存数据后**必须写回JSON文件**，否则程序重启数据丢失。
3. JSON存储的是时间字符串，做时间差运算，需要`DateTime.Parse()`转回时间对象。
4. 还车业务必须判断`ReturnTime != ""`，防止重复还车。
5. 当前原始版本没有异常处理，`int.Parse`、文件异常、非法输入直接造成程序崩溃。

## 8、项目不足与优化方向（面试口述）

1. 缺少`try‑catch`异常处理，输入非法字符、文件异常程序直接闪退。
2. 每次业务全量读写整个JSON文件，数据量大性能差；正式项目可以改用SQLite数据库。
3. 文件读写代码大量重复，可以封装通用JSON工具类。
4. 缺少日志、参数完整校验；租车还车没有事务，中途崩溃会出现数据不一致。

## 9、📝面试重点（控制台OOP项目，C#上位机笔试实操高频）

> 模拟面试问答形式，方便背诵记忆✨

**Q1：说说这个项目的分层思路？实体类和业务管理类分别承担什么职责？**

> A：分为三层😃
>
> 1. Model实体：只负责存储数据；
> 2. Manager管理类：封装全部业务逻辑、JSON读写；
> 3. Program程序入口：只做菜单交互，调用业务方法。 实现**业务逻辑和界面交互分离**。

**Q2：讲一下JSON文件持久化完整流程？**

> A：整体流程：判断文件是否存在 → 读取文本 → 反序列化为`List<实体对象>` → 在内存做增删改查 → 序列化 → 覆盖写回磁盘📂。

**Q3：简单描述租车完整业务流程？**

> A：
>
> 1. 获取用户输入：车辆ID、客户ID
> 2. 调用`UserManager.SearchOneById()`校验客户ID是否存在，不存在直接结束
> 3. 调用`CarManager.UpdateStatus()`，校验车辆存在、车辆处于空闲，把车辆状态修改为已出租
> 4. 读取租还记录json，生成新租还记录，自动生成记录Id，租车时间赋值当前时间，归还时间为空，费用0，最后写入文件✅

**Q4：简单描述还车完整业务流程？**

> A：
>
> 1. 用户输入租还记录ID，读取租还记录文件
> 2. Find查找对应记录；校验记录存在；校验归还时间为空（代表还未归还）
> 3. 调用`CarManager.UpAndGetInfo()`，把车辆状态改回空闲，同时获取时租单价
> 4. `TimeSpan diff = DateTime.Now - 租车时间`，总小时数 × 单价，计算应付金额💰
> 5. 回填归还时间`ReturnTime`、支付金额`PayMoney`；集合序列化，写回json文件

**Q5：为什么项目要用自定义实体类，不用Dictionary<string,dynamic>？**

> A：自定义实体类是编译期类型检查，如果字段写错，编译阶段就报错； `dynamic`字典是运行时才检查，字段拼写错误要运行程序才会暴露bug，维护麻烦⚠️。

**Q6：TimeSpan在项目中起到什么作用？**

> A：两个`DateTime`时间对象相减得到`TimeSpan`时间间隔；通过`TotalHours`拿到总小时数，用来计算租车租金。

> 工业视觉拓展：上位机开发同架构；Model对应缺陷、点位、产品实体；Manager封装业务；JSON/SQLite存储配置、检测记录。