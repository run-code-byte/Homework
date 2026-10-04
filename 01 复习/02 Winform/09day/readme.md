# fxday02 复习数据库

## 复习day08

### async和await

> async 修饰函数的，修饰的函数 返回值 `void  Task Task<T>`
>
> await 只能在async函数中使用，可以用于修饰`Task`
>
> ​	await 等待任务执行结束得到结果

MySql

> 关系型数据库
>
> > 如何建表，设计表

Sql

- `select * from 表名 where 条件`
  - `*`代表字段(*所以字段)
  - 条件：`=    !=    >    >=    <    <=    in    between 数字 and 数字    like` 
    - 条件合并：`and     or`
  - 聚合函数：`select count(*) as count,sum(*),avg(*),max(*),min(*) form 表名`
  - 排序分组
    - `select * from 表名 order by 字段 desc/asc`
    - `select count(字段) as count from 表名 group by 字段`
  - 分页：`select * from 表名 limit 开始下标，条数`

- `insert into 表名(字段...)  value()`
- `delete from 表名 where 条件`
- `update 表名 set 字段=新值... where 条件`

### 代码操作数据库-day09

- 安装使用`MysqlConnector`第三方库

```c#
//定义连接数据库字符串
string connStr=server=ip地址;port=3306;database=数据库;uid=登录名;password=密码;charset=字符串;
//连接数据库
using(MysqlConnection conn=new MysqlConnection(连接字符串)){
    //打开连接
    conn.Open();
    string sql = "...";
    using(MysqlCommand Cmd=new MysqlCommand(sql,conn)){
        //参数替换
        Cmd.Params.AddWithValue("@替换下的","替换上的")；
        //查询多个数据 需要再界面展示
        MysqlDataAdapter ada = new MysqlDataAdapter(Cmd);
        DataTable dt =new DataTable();
        ada.Fill(dt);
        //界面的表格
        table.DataSource=dt;
        
        //查询多个数据显示
        
        //单挑数据 查询
        var Reader = Cmd.ExecuteReader();
        bool isResult = Reader.Read();//isResult是都读取到数据
        
        Reader.GetString(索引/"字段名“);
        
        //非查询
        int rows = Cmd.ExecuteNonQuery();//rows 执行影响的行数
     
    }
        
}
```

