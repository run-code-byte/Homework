using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day03
{
    public partial class KeyTest2 : Form
    {
        public KeyTest2()
        {
            InitializeComponent();
            InitCtrl();
            InitNum();
        }

        public void InitNum()
        {
            textBox2.KeyPress += TextBox2_KeyPress;
        }

        private void TextBox2_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if(e.KeyChar<'0'||e.KeyChar>'9')
            {
                e.Handled = true;
            }
        }

        public void InitCtrl()
        {
            textBox1.KeyDown += TextBox1_KeyDown;
        }

        private void TextBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                MessageBox.Show("你要复制了吗");
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                MessageBox.Show("你要保存了吗");
            }
        }
    }
}
