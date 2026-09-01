using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using day07;

namespace day07.Controls
{
    public partial class UCBook : UserControl
    {
        public UCBook()
        {
            InitializeComponent();
        }

        public UCBook(string text)
        {
            InitializeComponent();
            label1.Text = "图书" + text;
            button1.Text = text;
        }

        // 保存编辑时原始Id，为null代表【新增模式】
        private string _editBookId;
        // 保存编辑时原始借阅状态
        private bool _editIsBorrow;

        internal event Action<BookInfo> SendData;

        /// <summary>
        /// 编辑回显数据方法
        /// </summary>
        /// <param name="book"></param>
        internal void SetBookInfo(BookInfo book)
        {
            //记录原有id和借阅状态
            _editBookId = book.Id;
            _editIsBorrow = book.IsBorrow;

            //回填各个输入框
            nameInp.Text = book.Name;
            authoInp.Text = book.Author;
            priceInpNum.Text = book.Price;
            input3.Text = book.BookLabl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookInfo book = new BookInfo();

            // 判断：编辑模式使用旧Id；新增模式生成新Guid
            if (string.IsNullOrEmpty(_editBookId))
            {
                //新增
                book.Id = Guid.NewGuid().ToString();
                book.IsBorrow = false;
            }
            else
            {
                //编辑：沿用原来Id和借阅状态
                book.Id = _editBookId;
                book.IsBorrow = _editIsBorrow;
            }

            book.Name = nameInp.Text;
            book.Author = authoInp.Text;
            book.Price = priceInpNum.Text;
            book.BookLabl = input3.Text;

            //向外抛出事件
            SendData?.Invoke(book);
        }
    }
}
