using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day04
{
    public partial class Form2 : Form
    {
        Label tipsLabel;
        public Form2()
        {
            InitializeComponent();
            InitLimitDelete();
            InitBigSmall();
            InitTips();
        }

        private void InitTips()
        {
            tipsLabel = new Label();
            tipsLabel.Name= "tipsLabel";
            tipsLabel.Text = "提示信息";
            Point tl=tipsLabel.Location;
            tl.X = button1.Location.X + button1.Width + 10;
            tl.Y = button1.Location.Y;
            tipsLabel.Location = tl;

            button1.MouseEnter += Button1_MouseEnter;
            button1.MouseLeave += Button1_MouseLeave;

        }

        private void Button1_MouseLeave(object? sender, EventArgs e)
        {
            this.Controls.Remove(tipsLabel);
        }

        private void Button1_MouseEnter(object? sender, EventArgs e)
        {
            this.Controls.Add(tipsLabel);
        }

        private void InitBigSmall()
        {
            panel1.MouseEnter += Panel1_MouseEnter;
            panel1.MouseLeave += Panel1_MouseLeave;
        }

        private void Panel1_MouseLeave(object? sender, EventArgs e)
        {
            //panel1.Width -= 100;
            //panel1.Height -= 100;
            panel1.Size = new Size(50, 50);
        }

        private void Panel1_MouseEnter(object? sender, EventArgs e)
        {
            //panel1.Width += 100;
            //panel1.Height += 100;
            panel1.Size = new Size(200, 200);

        }

        private void InitLimitDelete()
        {
            //textBox1.KeyPress += TextBox1_KeyPress;
            textBox1.KeyDown += TextBox1_KeyDown;
        }

        private void TextBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) { 
                //e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void TextBox1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char)8) e.Handled = true;
        }
    }
}
