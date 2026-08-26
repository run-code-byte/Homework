using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day03
{
    public partial class KeyTest : Form
    {
        public KeyTest()
        {
            InitializeComponent();
            InitEnter();
            InitEsc();
        }

        public void InitEsc()
        {
            textBox1.Visible = false;
            this.KeyDown += KeyTest_Keydown;
        }

        private void KeyTest_Keydown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        public void InitEnter()
        {
            textBox1.KeyUp += TextBox1_KeyUp;
        }

        private void TextBox1_KeyUp(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {
                MessageBox.Show("模拟提交");
            }
        }
    }
}
