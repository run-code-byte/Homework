using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day11
{
    public partial class Form3 : Form
    {
        private Book book = new Book(1, "三国", 99.9, true);
        public Form3()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", book, "Name");
            label1.DataBindings.Add("Text", book, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBox1.DataBindings.Add("Checked", book, "IsBorrow");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(book.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            book.Name = "西游记";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(book.Id.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            book.Id = 999;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "666";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(book.IsBorrow.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            book.IsBorrow=!book.IsBorrow;
        }
    }
}
