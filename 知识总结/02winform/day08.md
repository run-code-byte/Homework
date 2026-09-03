# day08｜MySQL数据库基础 + SQL语句 + C# MySqlConnector操作数据库 结构化总结

> 承接day07多线程Task‑async‑await；重点：数据库分类、MySQL库‑表‑字段结构、原生CRUD SQL、C# MySqlConnector库编码操作。

## 1、上节回顾

1. Task：`Task.Run()`启动任务；`.Result`会阻塞线程；`WhenAll()`全部完成；`WhenAny()`任意一个完成；`ContinueWith()`连续任务；`CancellationTokenSource`取消任务。
2. async/await：`await`非阻塞等待，**不要在UI线程用Result/Wait()，会卡死界面**。
3. MySqlConnector：C#操作MySQL第三方NuGet包；核心对象`MySqlConnection`、`MySqlCommand`、`MySqlDataAdapter`、`MySqlDataReader`；`using`自动释放连接；参数化`AddWithValue`防SQL注入。

## 2、数据库分类

### ①关系型数据库（表格形式存储）

> 数据组织成二维表格，行（记录）、列（字段）。 代表：**MySQL、SQL‑Server、Oracle**。

### ②非关系型数据库（NoSQL，字典/文档形式）

> 类似C# Dictionary，键值对存储。 代表：Redis（内存缓存）、MongoDB。

> 小皮(phpStudy)默认MySQL配置

- 地址：`127.0.0.1 / localhost`
- 端口：`3306`
- 账号：`root`
- 密码：`root`

## 3、MySQL层级结构

**数据库库 → 数据表 → 字段(表头)，行(数据记录)**

1. 新建数据库；双击数据库名字，库变绿色代表**选中打开该库**，才能操作里面的表。
2. 创建数据表：
   - 必须设置主键`id`：无符号、自增，作为每条记录唯一标识。
   - 定义各个字段名字、数据类型。
3. 保存表结构，完成建表。

## 4、基础SQL增删改查

### ✨新增 insert

```
--单条插入
insert into 表名(字段1,字段2) values(值1,值2);

--批量插入
insert into 表名(字段1,字段2) values(值1,值2),(值3,值4);
```

> 主键id设置自增，插入时不用写id字段，数据库自动生成。

### ✨删除 delete

```
delete from 表名 where 条件;
```

> ⚠️不带where条件会删除整张表全部数据！

### ✨修改 update

```
update 表名 set 字段1=值1,字段2=值2 where 条件;
```

> ⚠️不带where条件会更新整张表所有行！

### ✨查询 select

```
-- 查询全部列
select * from 表名;

--条件运算符 = > < != in like between…and
select * from 表名 where 条件;

--模糊查询 %通配符
select * from user where username like '%三%';
```

#### 常用条件关键字

| 关键字            | 说明                    |
| ----------------- | ----------------------- |
| `in(1,2,3)`       | 匹配多个值              |
| `between A and B` | 区间范围                |
| `like '%关键词%'` | 模糊查询，%代表任意字符 |
| `and / or`        | 并且 / 或者             |

#### 聚合函数（统计）

```
select sum(age) from user; --求和
select max(id) from user; --最大值
select avg(age) from user; --平均值
select count(*) from user; --统计行数
-- as 设置查询结果别名
select count(*) as total from user;
```

#### 排序、分页、分组

```
--order by 排序 desc降序，asc升序(默认)
select * from user order by age desc;

--limit 偏移量,条数 分页
select * from user limit 0,3;

--group by分组统计
select count(*) as count, banji from user group by banji;
```

## 5、C# MySqlConnector库操作MySQL

> NuGet安装`MySqlConnector`；`using MySqlConnector;`

### 核心对象

| 对象               | 功能                                        |
| ------------------ | ------------------------------------------- |
| `MySqlConnection`  | 数据库连接对象，**using自动释放关闭连接**   |
| `MySqlCommand`     | SQL命令对象，绑定sql语句与连接；支持参数化  |
| `MySqlDataAdapter` | 适配器，执行查询，填充`DataTable`内存数据表 |
| `MySqlDataReader`  | 数据流逐条读取，适合大量数据                |

### 连接字符串模板

```
string connStr = "server=127.0.0.1;port=3306;database=库名;uid=root;pwd=root;charset=utf8";
```

### ①查询：DataAdapter填充DataTable

```
using(MySqlConnection conn = new MySqlConnection(connStr))
{
    conn.Open();
    string sql = "select * from user where username=@name";
    using(MySqlCommand cmd = new MySqlCommand(sql,conn))
    {
        cmd.Parameters.AddWithValue("@name","张三"); //参数化
        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        //绑定DataGridView控件展示数据
        dataGridView1.DataSource = dt;
    }
}
```

### ②增删改 ExecuteNonQuery / ExecuteNonQueryAsync

返回值：**受影响的行数**

```
using(MySqlConnection conn = new MySqlConnection(connStr))
{
    conn.Open();
    string sql = "insert into user(username,password) values(@u,@p)";
    using(MySqlCommand cmd = new MySqlCommand(sql,conn))
    {
        cmd.Parameters.AddWithValue("@u","小明");
        cmd.Parameters.AddWithValue("@p","123456");
        int rows = cmd.ExecuteNonQuery();
    }
}
```

### ③聚合统计 ExecuteScalar / ExecuteScalarAsync

读取**第一行第一列**，适合count、max、sum等统计。

```
string sql = "select count(*) from user";
using(MySqlCommand cmd = new MySqlCommand(sql,conn))
{
    object res = cmd.ExecuteScalar();
}
```

### ④逐条读取 MySqlDataReader

适合大数据，流式读取，不全部加载到内存

```
using var reader = await cmd.ExecuteReaderAsync();
while(await reader.ReadAsync())
{
    int id = reader.GetInt32("id");
    string name = reader.GetString("username");
}
```

### ⑤数据库导入导出

1. 导出：数据库右键 → 导出 → 导出结构+数据，保存`.sql`文件。
2. 导入：新建空白数据库，右键【运行SQL文件】，选择sql脚本导入，刷新表。

## 6、易错点

1. MySQL操作前，数据库名字要双击选中，变成绿色，否则操作表报错。
2. `delete / update`**禁止忘记where条件**，会清空/修改整张表。
3. C#操作MySQL，连接对象必须套`using`，自动释放关闭连接，防止连接泄露耗尽。
4. 永远不要字符串拼接SQL；使用`AddWithValue("@参数",值)`参数化，**防止SQL注入攻击**。
5. 优先使用异步`OpenAsync`、`ExecuteNonQueryAsync`，UI程序避免阻塞主线程卡死界面。

## 7、工业视觉上位机拓展

1. MySQL存储产品信息、缺陷检测记录、工位参数、操作员日志。
2. 上位机分页查询大量缺陷记录使用`limit`分页。
3. count、sum、max聚合做报表统计。
4. 全部数据库IO使用异步API，防止WinForm界面卡死。
5. 参数化SQL，防止注入风险；using管理连接避免资源泄漏。

## 📝面试问答

**Q1：关系型数据库和非关系型数据库区别？😃**

> A：关系型数据库如MySQL，以二维表格行、列存储；适合结构化业务数据； 非关系型NoSQL(Redis/MongoDB)类似字典键值对，适合缓存、非结构化数据。

**Q2：delete语句如果不写where会发生什么？🤔**

> A：删除整张数据表里面全部记录，属于高危操作，开发严禁遗漏where条件。

**Q3：C#操作MySQL为什么要用AddWithValue参数化，不拼接SQL字符串？**

> A：防止SQL注入攻击；同时自动处理字符串引号、数据类型转换，避免语法错误。

**Q4：MySqlConnection为什么建议放在using里面？**

> A：using代码块结束自动释放、关闭数据库连接；不使用using容易发生连接泄露，耗尽数据库连接数。

**Q5：ExecuteScalar用途？**

> A：拿到查询结果第一行第一列；适合count统计、max、sum聚合查询。

> 工业视觉补充：产线上位机大量使用MySQL持久化检测报表；大数据量优先DataReader流式读取，避免一次性加载全部数据占用内存。

