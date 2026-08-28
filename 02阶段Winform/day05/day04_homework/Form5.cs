using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace day04_homework
{
    public partial class Form5 : Form
    {
        List<Dictionary<string, Control>> list = new List<Dictionary<string, Control>>();

        public Form5()
        {
            InitializeComponent();
            InitTotal();
        }

        private void InitTotal()
        {
            list.Add(new Dictionary<string, Control>() { 
                { "price", label6 }, 
                { "count", textBox1 } ,
                { "reduceBtn", button1 } ,
                { "addBtn", button2 }
            });
            list.Add(new Dictionary<string, Control>() { 
                { "price", label8 }, 
                { "count", textBox2 },
                { "reduceBtn", button3 },
                { "addBtn", button4 }
            });

            // 数量文本变化时自动重算总价
            list.ForEach(item => item["count"].TextChanged += TextChanged);
            list.ForEach(item => item["addBtn"].Click += Add);
            list.ForEach(item => item["reduceBtn"].Click += Reduce);






            GetTotal();
        }

        private void Reduce(object sender, EventArgs e)
        {
            Dictionary<string, Control> dic = list.Find(item => item["reduceBtn"] == (sender as System.Windows.Forms.Button));
            if (string.IsNullOrEmpty(dic["count"].Text))
            {
                dic["count"].Text = "0";
                (dic["count"] as System.Windows.Forms.TextBox).SelectionStart = 1;
            }
            int n = int.Parse(dic["count"].Text);
            if (n <= 0) return;
            dic["count"].Text = (--n).ToString();
        }

        private void Add(object sender, EventArgs e)
        {
            Dictionary<string, Control> dic = list.Find(item => item["addBtn"] == (sender as System.Windows.Forms.Button));
            if (string.IsNullOrEmpty(dic["count"].Text))
            {
                dic["count"].Text = "0";
                (dic["count"] as System.Windows.Forms.TextBox).SelectionStart = 1;
            }
            int n = int.Parse(dic["count"].Text);
            dic["count"].Text = (++n).ToString();
        }

        private void TextChanged(object? sender, EventArgs e)
        {
            GetTotal();
        }

    

        private void GetTotal()
        {
            int sum = 0;
            list.ForEach(item =>
            {
                if (string.IsNullOrEmpty(item["count"].Text)) return;
                else if (!Regex.IsMatch(item["count"].Text, @"^[1-9]\d*$"))
                {
                    item["count"].Text = "0";
                    (item["count"] as System.Windows.Forms.TextBox).SelectionStart = 1;
                }
                int price = int.Parse(item["price"].Text);
                int count = int.Parse(item["count"].Text);
                sum += price * count;
            });
            totalLab.Text = sum.ToString();
        }
    }
}
