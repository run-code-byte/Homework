using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day09.Book
{
    public partial class BookAddAndEdit : Form
    {
        private MySql MySql = new MySql("test");
        private string Id { get; set; } 
        private string Title { get; set; }
        public BookAddAndEdit()
        {
            InitializeComponent();

        }
        public BookAddAndEdit(string title)
        {
            InitializeComponent();
            label1.Text = "图书" + title;
            button1.Text = title;
            this.Title = title;
        }
        public BookAddAndEdit(string title,string id)
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
            string sql= "select * from book where id=@id";
            MySql.ConAndHandler(sql, (cmd) =>
            {
                cmd.Parameters.AddWithValue("@id", Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                bool isread = reader.Read();
                if(!isread)
                {
                   MessageBox.Show("编辑失败！！！");
                    this.Close();
                    return;
                } 
                input1.Text = reader.GetString("name");
                input2.Text = reader.GetString("author");
                inputNumber1.Text = reader.GetDouble("price").ToString();
                input3.Text = reader.GetString("lable").Replace("|", "\n");
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = input1.Text;
            string Author = input2.Text;
            double Price = double.Parse(inputNumber1.Text);
            string BookLable = input3.Text.Replace("\n", "|");
            string sql = "";
            if (this.Title == "新增")
            {
                sql = "insert into book(name,author,price,lable) value(@name,@author,@price,@lable)";
            }
            else
            {
                sql = "update book set name=@name,author=@author,price=@price,lable=@lable where id=@id";
            }

            
            MySql.ConAndHandler(sql, (cmd) =>
            {
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@author", Author);
                cmd.Parameters.AddWithValue("@price", Price);
                cmd.Parameters.AddWithValue("@lable", BookLable);
                if(this.Title== "编辑")
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                }
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(this.Title + "成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this.Title + "失败");
                }
            });
        }
    }
}
