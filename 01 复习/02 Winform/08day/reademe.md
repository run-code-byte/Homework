# 数据库

1、写连接字符串

```c#
 private string ConStr = "server=127.0.0.1;port=3306;database=test;uid=root;password=root;charset=utf8";
```

2、创建数据库连接

```c#
  using (MySqlConnection Conn = new MySqlConnection(ConStr))
```

3、打开连接

```
Conn.Open();
```

4、写sql语句

```
string Sql = "select * from user";
```

5、创建命令对象(传入sql和conn)

```
 using (MySqlCommand Comm = new MySqlCommand(Sql, Conn))
```

查询：

​	1、创建适配器(传命令对象)

```
MySqlDataAdapter Ada = new MySqlDataAdapter(Comm);
```

​	2、创建内存表

```
 DataTable dt = new DataTable();
```

​	3、数据填充

```
Ada.Fill(dt);
```

​	4、赋值给控件数据源

```
dataGridView1.DataSource = dt;
```



```c#
//精确查询
string Sql = "select * from user where username = @username";
//模糊查询
 string Sql = $"select * from user where username like '%{str}%'";
 string Sql = "select * from user where username like CONCAT('%', @username, '%')";
//Comm参数填充
string str = textBox1.Text; 
 Comm.Parameters.AddWithValue("@username", str);
```



增删改：

```c#
//删
string Sql = "delete from user where username = @username";
Comm.Parameters.AddWithValue("@username", "李四");

int row = Comm.ExecuteNonQuery();  //判断执行成功
if (row > 0)
{
    MessageBox.Show("成功");
}
else
{
    MessageBox.Show("失败");
}
//改
string Sql = "update user set gender = @gender,age=@age where id = @id";
//增
string Sql = "insert into user (username, gender, age,banji,password) values (@username, @gender, @age, @banji, @password)";

```



聚合查询：

```c#
string Sql = "select count(*) from user";
object res = Comm.ExecuteScalar();
label1.Text = res.ToString();
```



MySqlDataReader对象：

```c#
 string Sql = "select * from user where id = 1";
 MySqlDataReader Reader = Comm.ExecuteReader();
 //label1.Text = Reader.FieldCount.ToString();
 //label1.Text = Reader.HasRows.ToString();
bool isRow = Reader.Read();
//label1.Text = isRow.ToString();

//label1.Text = Reader.GetInt32(3).ToString();
//label1.Text = Reader.GetString("banji");
label1.Text = Reader.GetDateTime("create_at").ToString();
```