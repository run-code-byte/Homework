using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private int Labheight = 0;
        private Label Lab = new();
        private Random Rand = new();
        private System.Windows.Forms.Timer labTimer = new();
        private void button1_Click(object sender, EventArgs e)
        {
            SetLabel();
            labTimer.Interval= 10;
            labTimer.Tick -= LabTimer_Tick;
            labTimer.Tick += LabTimer_Tick;
            labTimer.Start();
            this.KeyPreview = true;
            this.ActiveControl = null;
            this.KeyUp -= Form2_KeyUp;
            this.KeyUp += Form2_KeyUp;
        }

        private void Form2_KeyUp(object? sender, KeyEventArgs e)
        {
            if (!Enum.TryParse(Lab.Text, true, out Keys k)) return;
            if(k==e.KeyCode)
            {
                panel1.Controls.Remove(Lab);
                SetLabel();
            }
            
        }

        private void LabTimer_Tick(object? sender, EventArgs e)
        {
            Labheight += 2;
            Lab.Top= Labheight;
            if (Lab.Top >= panel1.Height - 30)
            {
                labTimer.Stop();
                MessageBox.Show("Game Over!!!");
                panel1.Controls.Remove(Lab);
            }

        }

        private void SetLabel()
        {
            Labheight= 0;
            string str = "QWERTYUIOPASDFGHJKLZXCVBNM";
            Lab.Text = str[Rand.Next(str.Length)].ToString();
            Lab.Size = new Size(30, 30);
            Lab.Location = new Point(Rand.Next(panel1.Width - 30), 0);
            Lab.TextAlign = ContentAlignment.MiddleCenter;
            Lab.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point);
            panel1.Controls.Add(Lab);

        }
    }
}
