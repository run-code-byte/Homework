using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day06.myControl
{
    public partial class BookInfo : UserControl
    {
        public BookInfo(string bookname,string authoname,int price,string tag)
        {
            InitializeComponent();
            label2.Text= bookname;
            label4.Text= authoname;
            label6.Text=price.ToString();
            label8.Text = tag;
        }
        public BookInfo()
        {
            InitializeComponent();
        }
    }
}
