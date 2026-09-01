using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace day04
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            InitQD();
            InitQFWFG();
            InitToUpper();
        }

        private void InitToUpper()
        {
            textBox3.TextChanged += TextBox3_TextChanged;
        }

        private void TextBox3_TextChanged(object? sender, EventArgs e)
        {
            string content = (sender as TextBox).Text;
            content = content.ToUpper();
            (sender as TextBox).Text = content;
            (sender as TextBox).SelectionStart = content.Length;
        }

        private void InitQFWFG()
        {
            textBox2.TextChanged += TextBox2_TextChanged;
        }

        private void TextBox2_TextChanged(object? sender, EventArgs e)
        {
            string content = (sender as TextBox).Text;
            if(string.IsNullOrEmpty(content)) return;
            content = content.Replace(",", "");
            int res =int.Parse(content);
            string resStr= res.ToString("#,#");
            (sender as TextBox).Text = resStr;
            (sender as TextBox).SelectionStart=resStr.Length;
        }

        private void InitQD()
        {
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string pwd = (sender as TextBox).Text;
            int num = 0;
            string res = "";
            Color resColor;
            if (Regex.IsMatch(pwd, @"\d")) num++;
            if(Regex.IsMatch(pwd, @"[a-z]")) num++;
            if(Regex.IsMatch(pwd, @"[A-Z]")) num++;
            if(num==1) 
            {
                res= "弱";
                resColor = Color.Red;
            }
            else if (num == 2) {res = "中"; resColor = Color.Orange;}
            else if (num == 3) {res = "强"; resColor = Color.Green;}
            else { res="格式错误"; resColor = Color.Gray; }
            levelLab.Text = res;
            levelLab.ForeColor = resColor;
        }


        
    }
}
