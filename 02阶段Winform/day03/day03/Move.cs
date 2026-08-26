using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows.Forms;

namespace day03
{
    public partial class Move : Form
    {
        private int speed = 5;
        public Move()
        {
            InitializeComponent();
            this.KeyDown += Move_KeyDown;
        }

        private void Move_KeyDown(object? sender, KeyEventArgs e)
        {
            Point bl = box.Location;
            switch (e.KeyCode)
            {
                case Keys.W:
                    bl.Y -= speed;
                    break;
                case Keys.S:
                    bl.Y += speed;
                    break;
                case Keys.A:
                    bl.X -= speed;
                    break;
                case Keys.D:
                    bl.X += speed;
                    break;
                default:
                    break;
            }
            box.Location = bl;
        }
    }
}
