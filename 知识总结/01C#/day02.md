# day02｜var/dynamic、匿名类型、数组&List集合、Dictionary字典、Random随机数与嵌套数据结构知识总结

## 1、所学知识清单

### ① 上节回顾复习

- 基础简单类型：`int`、`double`、`string`、`bool`
- 变量定义、控制台输入输出、占位输出/插值输出
- `Console.ReadLine()`输入永远返回字符串；`int.Parse()` / `double.Parse()`字符串转数字
- 算术、赋值、`++/--`自增自减运算符，区分前置后置自增。

### ② var 类型推导 & dynamic动态类型

1. `var`：编译时推导类型，**定义时必须赋值**，确定类型后不能再赋值其他类型。
2. `dynamic`：运行时解析类型，编译不做类型检查，可以随意赋值不同类型数据。
3. `.GetType()` 获取变量运行时类型。

### ③ 匿名类型

- 语法：`var obj = new {name="xxx",age=18};`
- 只读对象，**不能修改属性、不能新增属性**，只能读取属性。

### ④ Dictionary<TKey,TValue> 字典（键值对集合）

- 键具有唯一性；键不能重复；值允许重复。
- 访问：`dic["键名"]`；新增/修改：`dic["键"]=值`；删除：`Remove(键)`；清空`Clear()`；统计数量`.Count`
- `TryGetValue(键, out 变量)`：安全获取键对应的值，不存在不会抛异常，返回bool。
- 支持字典嵌套，适合存储结构化参数。

### ⑤ 数组

- 固定长度容器，存储**相同类型**数据；下标从0开始。
- 多种初始化写法；数组长度属性：`.Length`；数组一旦定长，不能新增元素。

### ⑥ List 泛型集合（增强数组）

- 优势：长度可变，可以增删改查；下标从0开始；长度属性：`.Count`。
- 常用方法：`Add`、`AddRange`、`Insert`、`Remove`、`RemoveAt`、`RemoveRange`、`Clear`、`Contains`、`IndexOf`、`LastIndexOf`、`GetRange`、`Reverse`。

### ⑦ Random随机数

- `Random r = new Random();` 创建随机对象
- `r.Next(n)`：产生`[0,n)`整数；`r.Next(min,max)`产生`[min,max)`整数
- `r.NextDouble()`：返回0~1之间的double随机小数。

### ⑧ 组合数据结构

- `List<Dictionary<string,dynamic>>`：列表里面嵌套字典，用来保存多条业务数据（商品列表、歌曲列表），支持嵌套。

## 2、易错点

1. **var 必须定义的时候赋值**，`var a;`直接编译报错；var一旦确定类型，不能赋值别的类型。

```
var a = 10;
// a = "abc"; //编译报错
```

1. `dynamic`编译阶段不校验类型，**写错属性名字编译不报错误，运行时才抛异常**。
2. 匿名类型属性只读，不能修改属性，写`obj.name="xxx"`直接报错。
3. 字典直接用`dic["不存在的key"]`取值，**程序直接运行报错**；优先使用`TryGetValue`安全取值。
4. 数组是`.Length`，List是`.Count`，记混会编译报错。
5. List的`Insert(index,value)`，下标合法范围是`0 ~ list.Count`，超出范围抛异常。
6. `Remove(值)`是删除**第一个匹配元素**，不是全部；删除全部重复元素需要循环处理。
7. 执行`RemoveAt(index)`删除元素后，后面元素下标会向前移动；循环删除的时候如果不处理下标，会出现漏删。
8. Random对象不要写在循环内部反复new，短时间连续new会生成相同随机数。
9. AddRange的参数必须是集合，不能直接写零散多个值。

## 3、拓展

1. 实际工业上位机开发，尽量少用`dynamic`：dynamic跳过编译检查，bug只能运行时暴露，维护麻烦；优先使用强类型class/record代替匿名类型、dynamic字典存储业务数据。
2. 字典还有`TryAdd(key,value)`：key不存在才添加，存在直接返回false，不会抛异常，适合安全新增。
3. List更多拓展方法：`Find`、`FindAll`、`Exists`、`RemoveAll`、`Sort`、`ToArray()`，实际开发高频。
4. 嵌套`List<Dictionary<>>`适合快速写demo；正式项目定义实体类（Model）代替字典嵌套，可读性更高。
5. Random小坑：循环内重复实例化`new Random()`，因为系统时间种子相同，会产生重复随机数；建议全局只实例化一次Random对象。
6. C#12新集合语法 `int[] arr = [1,2,3];`、`List<int> list = [10,20,30];`，简化初始化代码。

## 4、面试重点

1. `var` 和 `dynamic` 的区别？（高频）

   > var编译期确定类型，定义必须赋值，强类型编译校验；dynamic运行时解析类型，编译不检查类型，可以随时赋值不同类型。

2. 数组和List的区别？`.Length`与`.Count`区别？

   > 数组长度固定，不能增删，属性`.Length`；List长度可变，支持增删各种方法，属性`.Count`。

3. Dictionary字典特点？键是否可以重复？直接索引访问不存在key会发生什么？如何安全取值？

   > key唯一不能重复；直接索引取不存在key抛出运行时异常；使用`TryGetValue(key, out var val)`安全获取。

4. `Remove()` 和 `RemoveAt()` 的区别

   > Remove：按**元素值**删除，删除第一个匹配项；RemoveAt：按下标索引删除。

5. 匿名类型有什么特点？能不能修改属性？

   > 使用var接收；属性只读；不能修改、新增属性。

6. Random为什么不要在循环里面不停new？

   > Random依靠系统时间作为种子；短时间多次new种子相同，生成重复随机数。

7. 什么场景用`List<Dictionary<string,dynamic>>`？项目实际开发为什么不推荐大量使用？

   > 快速构造多条结构化测试数据；但是没有编译类型校验，字段写错运行才报错，正式项目建议实体类。

> 工业视觉岗位补充：上位机开发中，List用来存储缺陷检测结果、产品记录；Dictionary用来保存相机参数、光源参数、设备配置。

