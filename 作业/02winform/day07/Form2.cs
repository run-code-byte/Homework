using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day07
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Book.BookAdd().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Book.BookEdit().Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Book.BookShow().Show();

        }
    }
}
