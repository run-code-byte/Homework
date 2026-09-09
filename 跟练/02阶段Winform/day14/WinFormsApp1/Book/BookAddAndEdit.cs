using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.Book
{
    public partial class BookAddAndEdit : Form
    {
        private Mysql MySql = new Mysql("test");
        private string Id { get; set; }
        private string Title { get; set; }
        public BookAddAndEdit()
        {
            InitializeComponent();
        }
        // 重写构造方法(新增)
        public BookAddAndEdit(string title)
        {
            InitializeComponent();
            label1.Text = "图书" + title;
            button1.Text = title;

            this.Title = title;
        }
        // 重写构造方法(编辑)
        public BookAddAndEdit(string title, string id)
        {
            InitializeComponent();
            label1.Text = "图书" + title;
            button1.Text = title;

            this.Title = title;
            this.Id = id;

            // 查询数据并回显(回填到界面)
            ShowBook();
        }
        private async void ShowBook()
        {
            string sql = "select * from book where id = @id";
            await MySql.ConAndHandler(sql, Cmd =>
            {
                // 参数填充
                Cmd.Parameters.AddWithValue("@id", Id);
                MySqlDataReader Reader = Cmd.ExecuteReader();

                bool IsRead = Reader.Read();
                if (!IsRead)
                {
                    MessageBox.Show("编辑失败!!!");
                    this.Close();
                    return false;
                }
                // Reader读到的数据 回填到窗体中
                input1.Text = Reader.GetString("name");
                input2.Text = Reader.GetString("author");
                // 注意: inputNumber控件的值 必须通过 Value设置  decimal 类型的值
                inputNumber1.Value = (decimal)Reader.GetDouble("price"); 
                input3.Text = Reader.GetString("label").Replace(" | ", "\n");

                return true;
            });


        }
        // 点击按钮实现 新增或编辑
        private async void button1_Click(object sender, EventArgs e)
        {
            // 获取数据
            string Name = input1.Text;
            string Author = input2.Text;
            double Price = (double)inputNumber1.Value;
            string BookLabel = input3.Text.Replace("\n", " | ");

            string sql = "";
            if (this.Title == "新增")
            {
                sql = "insert into book(name,author,price,label) value(@name,@author,@price,@label)";
            }
            else
            {
                sql = "update  book set name=@name,author=@author,price=@price,label=@label where id=@id";

            }
            // 数据库操作
            await MySql.ConAndHandler(sql, Cmd =>
            {
                // 填充参数
                Cmd.Parameters.AddWithValue("@name", Name);
                Cmd.Parameters.AddWithValue("@author", Author);
                Cmd.Parameters.AddWithValue("@price", Price);
                Cmd.Parameters.AddWithValue("@label", BookLabel);
                if(this.Title == "编辑") Cmd.Parameters.AddWithValue("@id", Id);

                // 执行
                int rows = Cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(this.Title+"成功");
                    this.Close();// 成功则关闭当前窗体
                }
                else
                {
                    MessageBox.Show(this.Title + "失败");
                }

                return true;

            });
        }
    }
}
