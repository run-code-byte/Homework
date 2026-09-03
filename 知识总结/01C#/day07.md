# day07｜类型转换、数字格式化、DateTime时间、JSON序列化、多维&交错数组知识总结

## 1、所学知识清单

### ① 上节回顾

- 字符串：`null`、`char`字符；字符串全套方法
- 正则表达式：元字符、量词、锚点、分组；`Regex.IsMatch/Match/Matches/Replace`

### ② 类型转换

1. **强制转换 (类型)变量**：只适合数值之间转换；浮点数转整数等价向下取整，**不能把字符串强制转数字**。
2. 安全解析 `int.TryParse(字符串, out int res)`
   - 返回bool代表是否转换成功；转换结果存入out参数res；**转换失败不会抛异常**，上位机输入解析高频使用。
3. `.ToString()`：任意对象转为字符串；**值为null调用会报错**。
4. `Convert.ToString()`：null安全，null输入返回空字符串。
5. 集合互转扩展方法
   - `.ToArray()`：List → 数组
   - `.ToList()`：数组 → List

### ③ 字符下标加密小案例

- 原理：利用文本的`IndexOf`找字符下标，通过下标做加密、解密；
- 可做偏移变换：下标±1、根据奇偶下标做不同偏移；解密时反向运算。

### ④ 数字转中文大写

- 思路：数字转为字符串，分别建立**数字汉字数组、单位汉字数组**；循环按位匹配，配合正则处理多余零、末尾零。

### ⑤ 数字格式化（`.ToString("格式符")`）

| 格式符 | 说明                                   |
| ------ | -------------------------------------- |
| `C/c`  | 货币格式，带货币符号、千分位、四舍五入 |
| `D/d`  | 十进制补零，仅整数可用                 |
| `F/f`  | 定点，保留指定小数位，四舍五入         |
| `N/n`  | 数字千分位分隔，保留小数               |
| `P/p`  | 百分比，自动×100                       |
| `X/x`  | 转十六进制，仅整数                     |
| `0`    | 零占位符，补位                         |
| `#`    | 数字占位符                             |

> 示例：`1234.5678.ToString("F3")` → `1234.568`

### ⑥ DateTime 时间对象

1. 获取时间
   - `DateTime.Now` 获取本机当前本地时间
   - `new DateTime(年,月,日,时,分,秒)` 构造指定时间
   - `DateTime.Parse("时间字符串")` 字符串解析为时间对象
2. 成员属性：`Year、Month、Day、Hour、Minute、Second、Millisecond、DayOfWeek`
3. 时间运算
   - `AddDays()、AddHours()、AddMinutes()`：时间增加
   - 两个DateTime相减得到`TimeSpan`时间间隔对象
   - `TimeSpan.TotalDays / TotalHours` 获取总天数、总小时数
4. 时间戳（Unix时间戳，毫秒）
   - `DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()` 获取时间戳
   - `DateTimeOffset.FromUnixTimeMilliseconds(毫秒数).DateTime` 时间戳转回时间
   - ⚠️注意：时间戳是UTC0时区，和北京时间相差+8小时，需要`AddHours(8)`校正。

### ⑦ 日期时间格式化

| 格式符           | 含义                                           |
| ---------------- | ---------------------------------------------- |
| `d`              | 短日期；`D`长日期                              |
| `t`              | 短时间；`T`长时间                              |
| `f/F`            | 完整日期时间；`g/G`常规日期时间                |
| `M`月日；`Y`年月 |                                                |
| `R`              | RFC1123格式，HTTP协议头部使用，GMT时区英文格式 |
| `U`              | UTC完整格式                                    |

### ⑧ JSON序列化与反序列化（`System.Text.Json`）

1. 命名空间：`using System.Text.Json;`

2. 序列化：

   ```
   JsonSerializer.Serialize(对象,配置)
   ```

    对象 → JSON字符串

   - ```
     JsonSerializerOptions
     ```

     配置类：

     - `WriteIndented = true`：美化格式化输出json；
     - `AllowTrailingCommas = true`：允许json末尾多余逗号。

3. 反序列化：`JsonSerializer.Deserialize<目标类型>(json字符串)` JSON字符串 → C#对象

4. 小技巧：可以利用反序列化直接解析Unicode转义中文`\uXXXX`。

### ⑨ 多维数组、交错数组

1. 规整多维数组（以二维数组 `int[,]` 举例）

   - 定义：`int[,] arr = new int[行数,列数]`；所有行的列数完全相等，表格、棋盘。
   - 获取维度长度：`GetLength(0)`获取行数；`GetLength(1)`获取列数。
   - 访问：`arr[行下标,列下标]`；整体是单个数组对象；长度固定不可扩容。

2. 交错数组 `int[][]`

   （数组套数组，“数组的数组”）

   - 外层数组每个元素是独立子数组；**子数组长度可以各不相同**。
   - 访问：`arr[i][j]`，两层独立下标。
   - 适合：参差不齐的数据，例如不同用户消息条数、各班人数不一样。
   - 可以单独替换某一个子数组；内存是多块独立数组。

## 2、易错点

1. `(int)str`不能将字符串强制转数字；字符串转数字必须使用`Parse / TryParse`。

2. `.ToString()` 如果对象是`null`直接报错；安全转换优先用`Convert.ToString()`。

3. 时间戳是UTC时区，转北京时间需要手动加8小时，否则时间差8小时。

4. `DateTime.Parse()`传入格式错误的时间字符串直接抛异常，项目可以考虑`DateTime.TryParse`安全解析。

5. JSON反序列化，类型必须匹配；类型写错运行时报错。

6. 二维数组

   ```
   int[,]
   ```

   和交错数组

   ```
   int[][]
   ```

   不要混淆：

   - `int[,]`：一个数组对象，`GetLength(0)`取行数，不能直接拿一行作为一维数组；
   - `int[][]`：外层数组存放多个独立子数组，子数组长度可以不一样。

7. 数字格式化F/N/P会自动**四舍五入**，工业测量场景注意精度问题。

## 3、拓展（工业视觉上位机场景）

1. `TryParse`非常高频：解析串口、TCP、PLC、MES上报字符串数字，防止非法输入程序崩溃。
2. DateTime：上位机保存检测记录、图片文件名、日志、MES上报时间戳；图片命名经常用时间字符串。
3. JSON：上位机和MES服务端交互，设备配置保存为JSON文件，读写配置。
4. 二维数组`int[,]`：相机标定矩阵、像素矩阵、棋盘标定；
5. 交错数组：缺陷分组、不同产品的不同点位，每组数量不一样。

## 4、面试重点

1. `Parse`和`TryParse`区别？

   > Parse转换失败直接抛异常；TryParse返回bool表示是否成功，结果放到out参数，不会崩溃，上位机优先用TryParse。

2. `ToString()`和`Convert.ToString()`区别？

   > 对象为null调用ToString()报空引用；Convert.ToString(null)返回空字符串，安全。

3. DateTime时间戳是什么？为什么时间戳转回来和本地时间差8小时？

   > 时间戳是UTC0时区毫秒数；北京时间UTC+8，需要AddHours(8)校正。

4. `int[,]`二维数组 和 `int[][]`交错数组区别？

   > `int[,]`规整多维数组，单块内存，行列全部等长；GetLength取维度长度； `int[][]`数组套数组，每个子数组独立，子数组长度可以不一样；两层下标访问。

5. System.Text.Json序列化常用配置？

   > `WriteIndented`美化输出；`AllowTrailingCommas`允许末尾逗号。

> 工业视觉岗位补充：
>
> - 设备报文解析大量使用TryParse，避免脏数据让程序崩溃；
> - 检测日志、图片文件名大量使用DateTime格式化；
> - 和MES接口交互使用JSON序列化；
> - 矩阵标定使用二维数组；不定长分组数据考虑交错数组或者List嵌套List。

