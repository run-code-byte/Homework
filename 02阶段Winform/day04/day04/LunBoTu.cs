using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day04
{
    public partial class LunBoTu : Form
    {
        private int speed = 10;
        private DateTime StartTime { get; set; }
      private bool flag = true;

        private void LunBoTu_KeyUp(object? sender, KeyEventArgs e)
        {
            flag = true;
            DateTime EndTime = DateTime.Now;
            TimeSpan diff=EndTime-StartTime;
            labeTime.Text = diff.TotalMilliseconds.ToString();
            label2.Text = n.ToString();
        }

      
        private int n = 0;
        private void Move_KeyDown(object sender, KeyEventArgs e)
        {
            if (flag) {
                n++;
                StartTime = DateTime.Now;
                flag = false;
            }
           


            Point bl = box.Location;
            int formWidth = this.Width;
            int formHeight = this.Height;
            int boxWidth = box.Width;
            int boxHeight = box.Height;
            int maxX = formWidth - boxWidth;
            int maxY = formHeight - boxHeight;
            switch (e.KeyCode)
            {
                case Keys.W:
                    bl.Y -= speed;
                    if(bl.Y < 0) bl.Y = 0;
                    break;
                case Keys.S:
                    bl.Y += speed;
                    if(bl.Y > maxY) bl.Y = maxY;
                    break;
                case Keys.A:
                    bl.X -= speed;
                    if(bl.X < 0) bl.X = 0;
                    break;
                case Keys.D:
                    bl.X += speed;
                    if(bl.X > maxX) bl.X = maxX;
                    break;
                default:
                    break;
            }
            box.Location = bl;

            if(e.KeyCode == Keys.Escape) this.Close();
        }
        public LunBoTu()
        {
            InitializeComponent();
            // 键盘控制方向移动
            this.KeyDown += Move_KeyDown;

            this.KeyUp += LunBoTu_KeyUp;
        }
    }
}
