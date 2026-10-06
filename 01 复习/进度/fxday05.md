# fxday05|图书管理系统-02winform-09day

## 图书管理系统登录页面

设计登录页面Login

工具控件：label input button



业务逻辑实现

修改页面跳转逻辑

首页按钮事件click，改为跳转到Login页面



增加按钮事件Click

写方法成员属性，把控件的输入给到变量，进行数据库参数化查询，通过是否返回查询判断登录

在谁那里new就是谁的子控件

Login是Form的子控件

给Login增加成员属性，event事件类型，只能订阅事件，不能直接覆盖或给null

在Form1中增加这个事件类型,增加成员属性Mark存储登录状态，进行已登录判断，控制页面跳转

```c#

Form1

private string Mark { get; set; }
  private void button1_Click(object sender, EventArgs e)
  {
      if(Mark == "已登录")
      {
          BookShow BS = new BookShow();
          BS.Show();
          this.Hide();
          BS.FormClosing += BS_FormClosing;
      }
      else
      {
          Login lg = new Login();
          lg.Show();
          lg.LoginMark += Lg_LoginMark;
          this.Hide();
          lg.FormClosing += (object? sender, FormClosingEventArgs e) => this.Show();
      }     
  }

  private void Lg_LoginMark(string mark)
  {
      this.Mark = mark;
      label2.Text = mark;
  }


Login


 private  Mysql Mysql = new Mysql("test");
 public event Action<string> LoginMark;
   private void button1_Click(object sender, EventArgs e)
   {
       string Name = input1.Text;
       string Password = input2.Text;

       if(Name.Trim()==""||Password.Trim() == "")
       {
           MessageBox.Show("用户名或密码不能为空");
           return;
       }
       string sql = @"select * from user where username=@name and password=@password";
       Mysql.ConAndHandler(sql,Cmd =>
       {
           Cmd.Parameters.AddWithValue("@name", Name);
           Cmd.Parameters.AddWithValue("@password", Password);
           MySqlDataReader Reader = Cmd.ExecuteReader();
           bool isLogin = Reader.Read();
           if(isLogin)
           {
               MessageBox.Show("登录成功");
               LoginMark?.Invoke("已登录");
               this.Close();
           }
           else
           {
               MessageBox.Show("用户名或密码错误");
               LoginMark?.Invoke("未登录");
               this.Close();
           }
       });
   }

```



解决bug，inputNumber控件值的显示问题，是Value不是Text



## 图书管理系统站页面表格操作按钮优化

[AntdUI: C# Ant Design 界面库](https://gitee.com/antdui?skip_mobile=true)

去AntdUI开源项目那里，查看文档，找到Table.md、TableColumn.md

去看代码，使用查找功能，找使用button的代码，复制粘贴到SetColumn()中，优化编辑和删除按钮



实现编辑和删除按钮，逻辑与之前的差不多

给BookShow里的table1控件增加事件**CellButtonClick**



```c#

BookShow
//给按钮绑定事件，实现跳转逻辑
table1.CellButtonClick += Table1_CellButtonClick;
 private void Table1_CellButtonClick(object sender, TableButtonEventArgs e)
 {
     System.Data.DataRow Book = e.Record as System.Data.DataRow;
     //MessageBox.Show(Book["name"].ToString());
     //MessageBox.Show(e.Btn.ToString());
     if (e.Btn.Text == "编辑")
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
     else if (e.Btn.Text == "删除")
     {
         Del(Book["id"].ToString());
     }
 }





//使用AntdUI的按钮，新增列操作
 var HandlerCol = new AntdUI.Column("handler", "操作");
 HandlerCol.SetAlign();
 HandlerCol.Render = (object val, object cel, int index) =>
 {
     var _btns = new AntdUI.CellLink[] {
         new AntdUI.CellButton("edit", "编辑", AntdUI.TTypeMini.Default),
         new AntdUI.CellButton("delete", "删除", AntdUI.TTypeMini.Default)
     };
     return _btns;
 };
 table1.Columns.Add(HandlerCol);
```



## 图书管理系统借还书

在SetColumn()中增加列操作

在CellButtonClick事件中写业务逻辑

```c#
table1.CellButtonClick += Table1_CellButtonClick;

//CellButtonClick
  else if (e.Btn.Text == "删除")
  {
      Del(Book["id"].ToString());
  }
  else if (e.Btn.Text == "借书"|| e.Btn.Text == "还书")
  {
      BorrowAndReturn(e.Btn.Text, Book["id"].ToString(), Book["is_borrow"].ToString());
  }
           

//SetColumn
var RetHandlerCol = new AntdUI.Column("resort", "借还书");
RetHandlerCol.SetAlign();
RetHandlerCol.Render = (object val, object cel, int index) =>
{
    return new AntdUI.CellLink[] {
        new AntdUI.CellButton("borrow", "借书", AntdUI.TTypeMini.Default),
        new AntdUI.CellButton("return", "还书", AntdUI.TTypeMini.Default)
    };
};
table1.Columns.Add(RetHandlerCol);

```



## 图书管理系统注册

设计界面Register

拖控件工具：label input inputNumber Radio button Select

设置属性：Text PlaceholderText Name TextAlign 

增加按钮事件Click，写登录业务逻辑

写属性接收控件input的输入，校验输入数据，使用正则，调用数据库，参数化查询、插入

```c#


 private Mysql Mysql = new Mysql("test");

 private async void button1_Click(object sender, EventArgs e)
 {
     string username = input1.Text.Trim();
     if(!Regex.IsMatch(username, @"^[0-9a-zA-Z]{4,15}$"))
     {
         MessageBox.Show("用户名格式有误！");
         return;
     }
     string password = input2.Text.Trim();
     if(password.Length < 6 || password.Length > 15)
     {
         MessageBox.Show("密码格式有误！");
         return;
     }
     if(password != input3.Text.Trim())
     {
         MessageBox.Show("两次输入的密码不一致！");
         return;
     }
     int age = (int)inputNumber1.Value;

     string gender = radio1.Checked ? "男" : "女";
     if(select1.SelectedValue == null)
     {
         MessageBox.Show("请选择班级！");
         return;
     }
     string banji = select1.SelectedValue.ToString();

     string checkSql = @"select * from user where username=@username";
     bool isUsernameAvailable = await Mysql.ConAndHandler(checkSql, Cmd =>
     {
         Cmd.Parameters.AddWithValue("@username", username);
         MySqlDataReader Reader = Cmd.ExecuteReader();
         if (Reader.Read())
         {
             MessageBox.Show("用户名已存在！");
             return false;
         }
         return true;
     });
     if(isUsernameAvailable == false)
     {
         
         return;
     }

     string sql = @"insert into user(username,password,age,gender,banji) values(@username,@password,@age,@gender,@banji)";
     await Mysql.ConAndHandler(sql, Cmd =>
     {
         Cmd.Parameters.AddWithValue("@username", username);
         Cmd.Parameters.AddWithValue("@password", password);
         Cmd.Parameters.AddWithValue("@age", age);
         Cmd.Parameters.AddWithValue("@gender", gender);
         Cmd.Parameters.AddWithValue("@banji", banji);
         int result = Cmd.ExecuteNonQuery();
         if (result > 0)
         {
             MessageBox.Show("注册成功！");
             this.Close();
         }
         else
         {
             MessageBox.Show("注册失败！");
         }
         return true;
     });
 }
```



优化了注册时重复注册问题，修改Mysql封装使用异步带Task<bool>，可以多次按顺序进行数据库操作

