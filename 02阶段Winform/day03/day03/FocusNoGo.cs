using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day03
{
    public partial class FocusNoGo : Form
    {
        public FocusNoGo()
        {
            InitializeComponent();
            InitFocusNoGo();
        }
        private void InitFocusNoGo()
        {
            tb1.Leave += Tb1_Leave;
            tb1.GotFocus += Tb1_GotFocus;

            lab.MouseEnter += Lab_MouseEnter;
            lab.MouseLeave += Lab_MouseLeave;
        }

        private void Lab_MouseLeave(object? sender, EventArgs e)
        {
            lab.ForeColor = Color.Blue;
            lab.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        private void Lab_MouseEnter(object? sender, EventArgs e)
        {
            lab.ForeColor = Color.Purple;
            lab.Font = new Font("Microsoft YaHei UI",9F, FontStyle.Underline,GraphicsUnit.Point);

        }

        private void Tb1_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            string content = tb.Text;
            if (!string.IsNullOrEmpty(content)) label1.Visible = false;
        }

        private void Tb1_Leave(object sender, EventArgs e)
        {
            TextBox tb=(sender as TextBox);
            string content = tb.Text;
            if (string.IsNullOrEmpty(content))
            {
                tb.Focus();
                label1.Visible = true;
            }
            //else
            //{
            //    label1.Visible = false;
            //}
        }

    
    }
}
