using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day02
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            initSwitch();
        }
        public void initSwitch() {
            button1.Click += Button1_Click;
        
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Text == "打开")
            {
                pictureBox1.Image = Image.FromFile(@"./images/on.png");
                btn.Text = "关闭";
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"./images/off.png");
                btn.Text = "打开";
            }
        }
    }
}
