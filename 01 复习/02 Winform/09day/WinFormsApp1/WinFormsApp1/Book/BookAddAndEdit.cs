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
        private Mysql Mysql { get; set; } = new Mysql("test");
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
        public BookAddAndEdit(string title, string id)
        {
            InitializeComponent();
            label1.Text = "图书" + title;
            button1.Text = title;

            this.Title = title;
            this.Id = id;
            ShowBook();
        }

        private async void ShowBook()
        {
            string sql = "select * from book where id=@id";
            await Mysql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@id", Id);
                using (var reader = Cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("未找到该图书");
                        this.Close();
                        return true;
                    }
                    else
                    {
                        //input1.Text = reader["name"].ToString();
                        //input2.Text = reader["author"].ToString();
                        //inputNumber1.Text = reader["price"].ToString();
                        //input3.Text = reader["label"].ToString().Replace("|", "\n");
                        input1.Text = reader.GetString("name");
                        input2.Text = reader.GetString("author");
                        inputNumber1.Value = (decimal)reader.GetDouble("price");
                        input3.Text = reader.GetString("label").Replace("|", "\n");
                    }
                }
                return true;
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string Name = input1.Text;
            string Author = input2.Text;
            double Price = double.Parse(inputNumber1.Value.ToString());
            string Label = input3.Text.Replace("\n","|");
            string sql = "";
            if (Title=="新增")
            {
                sql = @"insert into book(name,author,price,label) values(@name,@author,@price,@label)";
            }
            else if (Title == "编辑")
            {
                sql = @"update book set name=@name, author=@author, price=@price, label=@label where id=@id";
            }
           

            await Mysql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@name", Name);
                Cmd.Parameters.AddWithValue("@author", Author);
                Cmd.Parameters.AddWithValue("@price", Price);
                Cmd.Parameters.AddWithValue("@label", Label);
                if(this.Title == "编辑")
                {
                    Cmd.Parameters.AddWithValue("@id", Id);
                }
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(this.Title + "成功");
                    this.Close();
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
