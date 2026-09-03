# day10｜LINQ查询、面向对象OOP‑类、属性、访问修饰符、构造函数知识总结

## 1、所学知识清单

### ① 上节回顾

- 委托`Action/Func`；值类型&引用类型；`ref/out/params`；Lambda；元组；回调函数
- List高级查询方法：`Find/FindAll/Exists/TrueForAll/ConvertAll/RemoveAll`
- IO文件、目录、路径工具类`File / Directory / Path`

### ② LINQ（Language‑Integrated Query 语言集成查询）

> 用于集合（List、数组）做数据筛选、过滤、排序、分组、聚合；链式调用，需要引入命名空间`using System.Linq;`

#### 常用LINQ链式方法

| 方法                        | 作用                                                         |
| --------------------------- | ------------------------------------------------------------ |
| `Where(lambda)`             | 条件过滤，返回满足条件的元素集合                             |
| `Select(lambda)`            | 投影：转换/映射元素，提取部分字段，生成新集合                |
| `OfType<T>()`               | 按类型过滤集合，只返回指定类型元素                           |
| `OrderBy(lambda)`           | 升序排序                                                     |
| `OrderByDescending(lambda)` | 降序排序                                                     |
| `ThenBy(lambda)`            | **多条件排序**，一级排序相等后执行二级升序；`ThenByDescending`二级降序 |
| `DistinctBy(lambda)`        | 按指定字段去重                                               |
| `GroupBy(lambda)`           | 按指定键分组，返回分组集合；`.Key`获取分组键，迭代得到组内元素 |
| `FirstOrDefault(lambda)`    | 取第一个匹配元素；找不到返回类型默认值，不会抛异常           |
| `LastOrDefault(lambda)`     | 取最后一个匹配元素；找不到返回默认值                         |
| `Any(lambda)`               | 是否**至少存在一个**满足条件，返回bool                       |
| `All(lambda)`               | 是否**全部元素**满足条件，返回bool                           |

#### 聚合函数（统计）

- `Count()`：元素总个数；可传lambda做条件计数
- `Sum()`：求和
- `Average()`：求平均值
- `Max()`：最大值
- `Min()`：最小值

> 注意：LINQ查询返回的是**延迟执行序列IEnumerable**；真正遍历/调用聚合方法才会执行查询；可调用`.ToList()`立即转为List。

### ③ 面向对象OOP思想

1. **面向过程POP**：关注每一步执行过程，写函数、写逻辑，亲力亲为。

2. **面向对象OOP**：找现实事物抽象成类，调用对象属性、方法完成业务；三大特性：**封装、继承、多态**。

3. 类class：模板/图纸

   ；

   对象（实例）：new出来的实体

   。

   - 属性：事物的特征（数据）
   - 方法：事物的行为（函数逻辑）

#### 类定义与实例化

```
public class Animal
{
    // 属性 {get; set;} get读 set写
    public string Name { get; set; }
    public string Description { get; } //只读，只有get，不能赋值
    public void Run()
    {
        Console.WriteLine($"{Name}在跑");
    }
}
// new实例化对象
Animal bird = new Animal();
bird.Name = "鸟";
bird.Run();
```

- 属性访问器：`get`读取属性；`set`给属性赋值；只有get代表只读。
- 对象初始化器：`new Animal(){ Name="猫" }`，只能给带`set`的公开属性赋值。

### ④ 访问修饰符（控制可见范围）

| 修饰符      | 说明                                            |
| ----------- | ----------------------------------------------- |
| `public`    | 公开，**类内部、外部都可以访问**                |
| `private`   | 私有，**仅当前类内部访问**，默认不写就是private |
| `protected` | 受保护；当前类 + 子类可以访问，类外部不能访问   |
| `internal`  | 内部；**当前项目内可以访问**，其它项目不可见    |

> 搭配`static`静态成员：静态属性/方法**属于类本身，不属于实例对象**；使用`类名.静态成员`调用，不能用对象实例调用。 易错：普通实例方法可以访问静态；**静态方法不能直接访问实例成员，需要传入实例对象**。

### ⑤ 构造函数

1. 作用：实例`new`对象时**自动执行**，用于对象属性初始化赋值。
2. 规则：①方法名**和类名完全一致**；②**没有返回值，不写void**。
3. 无参默认构造函数：**不手写任何构造函数，编译器自动生成无参构造**；一旦手写自定义构造函数，默认无参构造就消失。
4. 自定义带参构造函数：实例化`new 类名(实参)`直接给成员赋值。

```
public Person(string name,int age)
{
    Name = name;
    Age = age;
}
Person p = new Person("张三",20);
```

## 2、易错点

1. LINQ需要引入命名空间`using System.Linq;`，忘记引用直接编译报错。
2. LINQ是**延迟执行**；多次遍历会重复执行查询逻辑；想要固定结果调用`.ToList()`缓存。
3. `FirstOrDefault`找不到元素返回**类型默认值**（引用类型返回null），直接访问属性会触发空引用异常，需要做判空。
4. 初始化器`new 类(){ }`只能赋值`public + set`的属性；`private / protected / 只读只有get`不能赋值。
5. 手写构造函数之后，编译器**不再提供默认无参构造**，再写`new Person()`会编译报错。
6. 静态成员属于类，实例成员属于对象；静态方法不能直接访问实例属性/方法。
7. 访问修饰符：不写修饰符，类里面成员**默认private私有**，外部访问直接报错。
8. `GroupBy`返回分组集合，通过`.Key`拿到分组标识，再循环拿到组内数据。

## 3、拓展（工业视觉上位机）

1. LINQ：上位机缺陷集合List大量做过滤、排序、分组统计；过滤NG缺陷、按缺陷面积排序、统计各类缺陷数量。

2. 面向对象：

   上位机核心

   ；把相机、PLC、光源、产品、缺陷封装成类。

   - 相机类：属性（IP、端口、相机状态）；方法`Open()、Close()、Capture()`拍照。
   - 缺陷类：属性坐标、面积、类型；

3. 访问修饰符：字段尽量`private`，对外暴露`public`属性；保护内部数据安全，封装。

4. 构造函数：实例化相机对象时传入IP参数，完成初始化。

5. static：工具类（算法转换、参数转换）全部写静态方法，不用new对象直接类名调用。

## 4、面试重点

1. LINQ是什么？延迟执行是什么，怎么立即执行？

   > LINQ语言集成查询，对集合做筛选排序分组；延迟执行：遍历的时候才真正执行查询；调用`.ToList()`/聚合函数可以立即执行拿到结果。

2. `First()`和`FirstOrDefault()`区别？

   > First找不到直接抛异常；FirstOrDefault找不到返回类型默认值，不抛异常；引用类型注意判null。

3. OrderBy、ThenBy作用？

   > OrderBy第一条件排序；ThenBy在一级排序相等的情况下执行二级排序，做多字段排序。

4. 类和对象的区别？

   > 类是模板、抽象定义；对象是`new`出来的实例实体；一个类可以new多个独立对象。

5. get/set属性访问器作用；只读属性怎么写？

   > get读取，set赋值；只写`get`不写set就是只读属性。

6. 访问修饰符public/private/protected/internal区别。

   > public全部可见；private仅本类内部；protected本类+子类；internal本项目可见。

7. 构造函数特点；手写构造函数之后默认无参构造会怎么样？

   > 与类同名，无返回值；new实例自动调用；手写构造，编译器不再生成默认无参构造。

8. static静态成员和实例成员区别，调用方式？

   > 静态属于类，类名.xxx调用；实例属于对象，new对象调用；静态方法不能直接访问实例成员。

> 工业视觉补充：
>
> - 缺陷List大量使用LINQ Where过滤NG、OrderBy按面积排序、GroupBy统计缺陷类型数量；
> - 相机、PLC、光源、产品实体全部封装class；构造函数传入连接参数；工具类大量static静态方法。

