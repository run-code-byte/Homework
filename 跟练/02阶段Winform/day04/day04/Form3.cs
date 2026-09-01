using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day04
{
    public partial class Form3 : Form
    {
        private string[] strArr = { "123223", "2222333", "3334444", "4445555", "5556666", "6667777", "7778888" };

        public Form3()
        {
            InitializeComponent();
            InitLimitLength();
            InitFilterList();
            //button1.Click += Button1_Click;
        }

        //private void Button1_Click(object? sender, EventArgs e)
        //{
        //    string str = "";
        //    foreach(var item in listBox1.Items)
        //    {
        //        str += item.ToString() + ",";
        //    }
        //    MessageBox.Show(str);
        //}

        private void InitFilterList()
        {
            listBox1.Items.AddRange(strArr);
            textBox2.TextChanged += TextBox2_TextChanged;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            selectedLab.Text = listBox1.SelectedItem.ToString();

        }

        private void TextBox2_TextChanged(object? sender, EventArgs e)
        {
            string keyWords = (sender as TextBox).Text;
            List<string> resList= strArr.ToList().FindAll(item=>item.Contains(keyWords));
            listBox1.Items.Clear();
            listBox1.Items.AddRange(resList.ToArray());
        }

        private int MaxLength= 10;
        private void InitLimitLength()
        {
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object? sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Length >= MaxLength)
            {
                tipsLab.Visible = true;
                string maxContent= tb.Text.Substring(0, MaxLength);
                tb.Text = maxContent;
                tb.SelectionStart = MaxLength;
            }

        }
    }
}
