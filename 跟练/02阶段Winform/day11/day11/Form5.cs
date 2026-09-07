using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day11
{
    public partial class Form5 : Form
    {
        private BindingList<Book> books { get; set; } = new BindingList<Book>();
        public Form5()
        {
            InitializeComponent();
            books.Add(new Book(1, "三国", 99.9, true));
            books.Add(new Book(2, "西游记", 88.8, false));
            books.Add(new Book(3, "水浒传", 77.7, true));
            books.Add(new Book(4, "红楼梦", 66.6, false));

            dataGridView1.DataSource = books;

            //dataGridView1.AllowUserToAddRows = true;
        }
    }
}
