using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day05
{
    public partial class Form6 : Form
    {
        private Form5 f5;
        public Form6()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            button2.Click += (object sender, EventArgs e) =>
            {
                f5.Close();
            };
            button3.Click += (object sender, EventArgs e) =>
            {
                f5.Hide();
            };
            button4.Click += (object sender, EventArgs e) =>
            {
                Application.Exit();
            };
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            f5=new Form5();
            f5.Show();
        }
    }
}
