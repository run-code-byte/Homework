using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day05
{
    public partial class Form5 : Form
    {
        private Point P;

        private bool flag;
        public Form5()
        {
            InitializeComponent();
            button1.MouseDown += Button1_MouseDown;
            button1.MouseMove += Button1_MouseMove;
            button1.MouseUp += Button1_MouseUp;

            richTextBox1.GotFocus += RichTextBox1_Focus;
        }

        private void RichTextBox1_Focus(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!flag) return;
            Point m_s = button1.PointToScreen(e.Location);
            m_s.Offset(-P.X, -P.Y);
            Point b_f = this.PointToClient(m_s);
            if(b_f.X < 0) b_f.X = 0;
            if (b_f.Y < 0) b_f.Y = 0;
            int MaxX = this.Width - button1.Width;
            int MaxY = this.Height - button1.Height;
            if(b_f.X > MaxX) b_f.X = MaxX;
            if (b_f.Y > MaxY) b_f.Y = MaxY;
            button1.Location = b_f;
        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            P= e.Location;

            //MessageBox.Show(e.X.ToString());
            //Point m_s=button1.PointToScreen(e.Location);
            //MessageBox.Show(m_s.X.ToString());

            //m_s.Offset(-e.X, -e.Y);
            //MessageBox.Show(m_s.X.ToString());

            //Point b_f=this.PointToClient(m_s);
            //MessageBox.Show(b_f.X.ToString());
        }
    }
}
