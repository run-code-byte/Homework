using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace day03
{
    public partial class CursorLocation : Form
    {
        public CursorLocation()
        {
            InitializeComponent();
            this.MouseMove += This_MouseMove;

            textBox1.Leave += TextBox1_Leave;
            textBox1.GotFocus += TextBox1_GotFocus;
        }

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            labT.Visible = false;
            labF.Visible = false;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            string content = (sender as TextBox).Text;
            if(Regex.IsMatch(content, @"^1[1-9]\d{9}$"))
            {
                labT.Visible = true;
            }
            else
            {
                labF.Visible = true;
            }
        }

        private void This_MouseMove(object sender, EventArgs e)
        {
            MouseEventArgs ev = (e as MouseEventArgs);
            lab1.Text = ev.X.ToString();
            lab2.Text = ev.Y.ToString();
        }
    }
}
