# fxday04|图书管理系统-02winform-day09

## 图书管理系统

数据库设计

### 1、设计字段：

id 自动递增 无符号

name 默认-NULL 注释-图书名称 字符集-utf8 排序规则-utf8_general_ci

author 默认-NULL 注释-作者 字符集-utf8 排序规则-utf8_general_ci

price 默认-NULL 注释-图书价格

label 默认-NULL 注释-图书标签 字符集-utf8 排序规则-utf8_general_ci

is_borrow 值-‘2’，‘1’ 默认-NULL 注释-是否借阅 字符集-utf8 排序规则-utf8_general_ci

```sql
--DDL
CREATE TABLE `book`(
	`id` int(10) unsingne NOT NULL AUTO_INCREMENT,
    `name` varchar(255) DEFAULT NULL COMMENT '图书名称',
    `author` varchar(255) DEFAULT NULL COMMENT '作者',
    `price` double DEFAULT NULL COMMENT '图书价格',
    `label` varchar(255) DEFAULT NULL COMMENT '图书标签',
    `is_borrow` enum('2','1') DEFAULT '2' COMMENT '是否借阅',
    PRIMARY KEY(`id`)
)ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
```

### 2、页面跳转设计

首页跳转到图书管理系统展示页面

#### **Form1** 

1、点击按钮，触发事件Click ，展示页面，隐藏首页

```c#
 private void button1_Click(object sender, EventArgs e)
 {
     BookShow BS = new BookShow();
     BS.Show();
     this.Hide();
     BS.FormClosing += BS_FormClosing;
 }
```

2、展示页面关闭时触发事件，返回首页

```c#
  private void BS_FormClosing(object? sender, FormClosingEventArgs e)
  {
      this.Show();
  }
```

3、展示页面数据显示与操作

#### **BookShow**

**回忆Mysql封装**

1、写属性Server Port Database Uid Password Charset 根据需要给默认值，再写一个连接字符串的属性ConnStr

2、写构造方法：Mysql(string database)

3、设计功能方法：**ConAndHandler(string sql , Action<MySqlCommand> handlerCall)** 连接并操作数据库 (拼接连接字符串ConnStr、创建连接对象Conn=MySqlConnection(ConnStr)、打开连接Conn.openAsync()、创建命令对象Cmd=MySqlCommand(sql,Conn)),由于操作数据库代码各有不同，所以方法参数传入sql、Action<MySqlCommand>

```c#
 public string Server { get; set; } = "127.0.0.1";
 public string Port { get; set; } = "3306";
 public string Database { get; set; }
 public string Uid { get; set; } = "root";
 public string Password { get; set; } = "root";
 public string Charset { get; set; } = "utf8";

 private string ConnStr { get; set; }

 public Mysql(string database)
 {
     this.Database = database;
 }
 public async void ConAndHandler(string sql,Action<MySqlCommand> handlerCall)
 {
     ConnStr = $"server={Server};port={Port};database={Database};uid={Uid};password={Password};charset={Charset}";
     using(MySqlConnection Conn = new MySqlConnection(ConnStr))
     {
         await Conn.OpenAsync();
         using(MySqlCommand Cmd = new MySqlCommand(sql, Conn))
         {
             handlerCall(Cmd);
         }
     }
 }
```



写方法ShowData()，完成数据库数据展示在页面中







1、使用封装的Mysql,给table控件提供数据

```c#
//定义Mysql,给默认值
private Mysql Mysql { get; set; } = new Mysql("test");

//调用Mysql里的方法，连接并操作数据库(创建连接对象、打开连接、创建命令对象)
 Mysql.ConAndHandler("select * from book", Cmd =>
 {
     MySqlDataAdapter Ada = new MySqlDataAdapter(Cmd);
     DataTable dt = new DataTable();
     Ada.Fill(dt);
     table1.DataSource = dt;
     //重新设计表头
     SetColumn();
 });
```



2、设置表头、增加字段列**操作**

SetColumn()

```c#
//写SetColumn()，把表头字段换成中文，再增加一列操作字段
 private void SetColumn()
 {
     table1.Columns.Clear();
     table1.Bordered = true;
     table1.Radius = 4;
     table1.Columns = new AntdUI.ColumnCollection()
     {
         new AntdUI.Column("id", "编号")
         {
             Render=(object val,object cel,int rowindex)=>rowindex+1
         },
         new AntdUI.Column("name","书名"),
         new AntdUI.Column("author","作者"),
         new AntdUI.Column("price","价格"),
         new AntdUI.Column("label","标签"),
         new AntdUI.Column("is_borrow","借阅") {
             Render=(object val,object cel,int index)=>val.ToString()=="1"?"已借阅":"在书架"
         },
     };
     var HandlerCol = new AntdUI.Column("handler", "操作");
     HandlerCol.Render = (object val, object cel, int index) => "删除|编辑";
     table1.Columns.Add(HandlerCol);
 }

```



给新增按钮增加事件Click(双击按钮)，跳转页面BookAndEdit

```c#
     private void button1_Click(object sender, EventArgs e)
     {
         BookAddAndEdit BA = new BookAddAndEdit();
         BA.Show();
         this.Hide();
         BA.FormClosing += BA_FormClosing;
     }

     private void BA_FormClosing(object? sender, FormClosingEventArgs e)
     {
         this.Show();
     }
```









#### **BookAndEdit**

1、设计页面，拖工具控件：label button inputtext inputNumber

如果前面有重复的可以复制粘贴



2、业务逻辑

重写构造方法，传入参数title

定义封装类Mysql

给按钮增加事件click，进行数据库操作，使用@参数化查询（$插值会导致SQL注入，有安全隐患）

执行查询，若有返回就说明成功添加，关闭新增页面，触发关闭事件

```c#
 //重写构造方法，给标签和按钮传值
public BookAddAndEdit(string title)
 {
     InitializeComponent();
     label1.Text = "图书" + title;
     button1.Text = title;
 }
//定义封装类Mysql
private Mysql Mysql { get; set; } = new Mysql("test");

//编辑Click事件逻辑，操作数据库，使用参数化查询
private void button1_Click(object sender, EventArgs e)
  {
      string Name = input1.Text;
      string Author = input2.Text;
      double Price = double.Parse(inputNumber1.Text);
      string Label = input3.Text.Replace("\n","|");

      string sql = @"insert into book(name,author,price,label) values(@name,@author,@price,@label)";

      Mysql.ConAndHandler(sql, Cmd =>
      {
          Cmd.Parameters.AddWithValue("@name", Name);
          Cmd.Parameters.AddWithValue("@author", Author);
          Cmd.Parameters.AddWithValue("@price", Price);
          Cmd.Parameters.AddWithValue("@label", Label);
          int result = Cmd.ExecuteNonQuery();
          if (result > 0)
          {
              MessageBox.Show("添加成功");
              this.Close();
          }
          else
          {
              MessageBox.Show("添加失败");
          }
      });
  }
```

编辑业务逻辑

在展示页面增加事件CellClick，触发时弹出对话框，选择操作

若是编辑就跳转去编辑页面，删除就实现删除逻辑

编辑：重写构造方法，增加id参数，进行数据回填

```c#
BookShow

//增加数据表的点击事件
table1.CellClick += Table1_CellClick;
//弹出对话框，选择操作
 private void Table1_CellClick(object sender, TableClickEventArgs e)
 {
     //MessageBox.Show(e.ColumnIndex.ToString());
     //MessageBox.Show(e.RowIndex.ToString());
     //MessageBox.Show(e.Column.Key.ToString());
     //System.Data.DataRow Book = e.Record as System.Data.DataRow;
     //MessageBox.Show(Book["name"].ToString());
     //MessageBox.Show(Book[1].ToString());

     System.Data.DataRow Book = e.Record as System.Data.DataRow;
     DialogResult res = MessageBox.Show("编辑还是删除？\n是=编辑\n否=删除", "编辑删除", MessageBoxButtons.YesNoCancel);
     if(res== DialogResult.Yes)
     {
         BookAddAndEdit BE = new BookAddAndEdit("编辑", Book["id"].ToString());
         BE.Show();
         this.Hide();
         BE.FormClosing += (object sender, FormClosingEventArgs args) =>
         {
             this.Show();
             ShowData();
         };
     }
     //实现删除操作
     else if(res == DialogResult.No)
     {
         //代码多，写方法
		Del(Book["id"].ToString());
     }

 }
  private void Del(string id)
  {
      Mysql.ConAndHandler("delete from book where id=@id", Cmd =>
      {
          Cmd.Parameters.AddWithValue("@id", id);
          int res = Cmd.ExecuteNonQuery();
          if (res > 0)
          {
              MessageBox.Show("删除成功");
              ShowData();
          }
          else
          {
              MessageBox.Show("删除失败");
          }
      });
  }


BookAddAndEidt

//重写构造方法，给编辑实现数据回填
 public BookAddAndEdit(string title, string id)
 {
     InitializeComponent();
     label1.Text = "图书" + title;
     button1.Text = title;

     this.Title = title;
     this.Id = id;
     ShowBook();
 }
  private void ShowBook()
  {
      string sql = "select * from book where id=@id";
      Mysql.ConAndHandler(sql, Cmd =>
      {
          Cmd.Parameters.AddWithValue("@id", Id);
          using (var reader = Cmd.ExecuteReader())
          {
              if (!reader.Read())
              {
                  MessageBox.Show("未找到该图书");
                  this.Close();
                  return;
              }
              else
              {
                  //input1.Text = reader["name"].ToString();
                  //input2.Text = reader["author"].ToString();
                  //inputNumber1.Text = reader["price"].ToString();
                  //input3.Text = reader["label"].ToString().Replace("|", "\n");
                  input1.Text = reader.GetString("name");
                  input2.Text = reader.GetString("author");
                  inputNumber1.Text = reader.GetDouble("price").ToString();
                  input3.Text = reader.GetString("label").Replace("|", "\n");
              }
          }
      });
  }
```

