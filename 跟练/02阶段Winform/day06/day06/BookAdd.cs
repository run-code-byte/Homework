using day06.myControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using day06.myControl;
/*
 图书新增界面

要求:  将新增界面的公共内容提取 使用 用户控件 实现
 
 */


namespace day06
{
    public partial class BookAdd : Form
    {
        public BookAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bookname = input1.Text;
            string authoname = input2.Text;
            int price = int.Parse(inputNumber1.Text);
            string tag = input4.Text;
            BookInfo book = new BookInfo(bookname,authoname,price,tag);
            flowLayoutPanel1.Controls.Add(book);
        }
    }
    public class Book
    {
        public string bookname { get; set; }
        public string authoname { get; set; }
        public int price { get; set; }
        public string tag { get; set; }
        public string uid { get; set; }
        public Book(string bookname, string authoname, int price, string tag,string uid)
        {
            this.bookname = bookname;
            this.authoname = authoname;
            this.price = price;
            this.tag = tag;
            this.uid = uid;
        }
    }
}
