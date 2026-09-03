using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day10v2
{
    public partial class Form2 : Form
    {
        private System.Windows.Forms.Timer MyTimer { get; set; }
        private int n = 0;
        public Form2()
        {
            InitializeComponent();
            MyTimer = new System.Windows.Forms.Timer();
            MyTimer.Interval = 1000;
            MyTimer.Tick += (Object sender, EventArgs e) =>
            {
                n++;
                label1.Text = n.ToString();
            };
            MyTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTimer.Stop();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MyTimer.Start();
        }
    }
}
