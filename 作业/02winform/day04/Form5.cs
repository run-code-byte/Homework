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
            list.Add(new Dictionary<string, Control>() { { "price", label6 }, { "count", textBox1 } });
            list.Add(new Dictionary<string, Control>() { { "price", label8 }, { "count", textBox2 } });

            // 数量文本变化时自动重算总价
            list.ForEach(item =>
            {
                item["count"].TextChanged += TextChanged;
            });

            // 加减按钮：第一行用 button1/button2，第二行用 button3/button4
            button1.Click += (s, e) => ChangeCount(textBox1, -1);   // 西红柿 -
            button2.Click += (s, e) => ChangeCount(textBox1, 1);    // 西红柿 +
            button3.Click += (s, e) => ChangeCount(textBox2, -1);   // 鸡蛋 -
            button4.Click += (s, e) => ChangeCount(textBox2, 1);    // 鸡蛋 +

            GetTotal();
        }

        private void TextChanged(object? sender, EventArgs e)
        {
            GetTotal();
        }

        // 点击 + / - 修改数量
        private void ChangeCount(TextBox tb, int delta)
        {
            if (!int.TryParse(tb.Text, out int count) || count < 1)
                count = 1;

            count += delta;
            if (count < 1) count = 1;          // 数量最小为 1，不会出现 0 或负数

            tb.Text = count.ToString();
            tb.SelectionStart = tb.Text.Length; // 光标移到末尾
            // 给 Text 赋值会自动触发 TextChanged → GetTotal()，总价随之更新
        }

        private void GetTotal()
        {
            int sum = 0;
            list.ForEach(item =>
            {
                if (!Regex.IsMatch(item["count"].Text, @"^[1-9]\d*$"))
                {
                    item["count"].Text = "1";
                    (item["count"] as TextBox).SelectionStart = 1;
                }
                int price = int.Parse(item["price"].Text);
                int count = int.Parse(item["count"].Text);
                sum += price * count;
            });
            totalLab.Text = sum.ToString();
        }
    }
}
