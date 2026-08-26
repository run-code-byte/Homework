using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day03
{
    public partial class FocusWork : Form
    {
        public FocusWork()
        {
            InitializeComponent();
            InitFocusHeightLigh();
            InitFocusOpen();
        }

        private void InitFocusOpen()
        {
            comboBox1.Leave += ComboBox1_Leave;
            comboBox1.GotFocus += ComboBox1_GotFocus;
        }

        private void ComboBox1_GotFocus(object? sender, EventArgs e)
        {
            (sender as ComboBox).DroppedDown = true;
        }

        private void ComboBox1_Leave(object? sender, EventArgs e)
        {
            (sender as ComboBox).DroppedDown = true;

        }

        private void InitFocusHeightLigh()
        {
            button1.Leave += Button1_Leave;
            button1.GotFocus += Button1_GotFocus;

            textBox1.Leave += TextBox1_Leave;
            textBox1.GotFocus += TextBox1_GotFocus;
        }

        private void TextBox1_GotFocus(object? sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Orange;
            (sender as TextBox).ForeColor = Color.Blue;
            (sender as TextBox). BorderStyle= BorderStyle.Fixed3D;
        }

        private void TextBox1_Leave(object? sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
            (sender as TextBox).ForeColor = Color.Black;
            (sender as TextBox). BorderStyle= BorderStyle.FixedSingle;
        }

        private void Button1_GotFocus(object? sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Orange;
            (sender as Button).ForeColor = Color.Blue;
        }

        private void Button1_Leave(object? sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.White;
            (sender as Button).ForeColor = Color.Black;
        }
    }
}
