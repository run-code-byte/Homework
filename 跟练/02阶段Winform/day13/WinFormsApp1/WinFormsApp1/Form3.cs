using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Shown += GameInit;
        }
        private Random Rand = new();
        private System.Windows.Forms.Timer GolbalTimer = new();
        private List<LabeAndTimer> LabTimerList = new();
        private int score = 0;
        private void GameInit(object? sender, EventArgs e)
        {
            GolbalTimer.Interval = 1000;
            GolbalTimer.Tick += (object seander, EventArgs e) => CreateLab();
            this.KeyPreview = true;
            this.ActiveControl = null;
            this.KeyUp += Form3_KeyUp;
        }

        private void Form3_KeyUp(object? sender, KeyEventArgs e)
        {
            for (int i = 0; i < LabTimerList.Count; i++)
            {
                //LabTimerList[i].Lab.Text
                if (Enum.TryParse(LabTimerList[i].Lab.Text,true,out Keys k))
                {
                    if (k != e.KeyCode) continue;
                    panel1.Controls.Remove(LabTimerList[i].Lab);
                    LabTimerList[i].LabTimer.Stop();
                    LabTimerList.RemoveAt(i);
                    label2.Text=(++score).ToString();
                    return;
                }
            }
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            score = 0;
            label2.Text = "0";

            GolbalTimer.Start();
        }

        private void CreateLab()
        {
            Label lab = new Label();
            lab.Text=((char)Rand.Next(65, 90)).ToString();
            lab.Size = new Size(30, 30);
            lab.Location = new Point(Rand.Next(panel1.Width - 30), 0);
            lab.TextAlign = ContentAlignment.MiddleCenter;
            lab.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point);
            panel1.Controls.Add(lab);
            System.Windows.Forms.Timer lt = new();
            lt.Interval = 10;
            lt.Tick += (object seander, EventArgs e) => LabeDown(lab);
            lt.Start();
            LabTimerList.Add(new LabeAndTimer(lab,lt));
            //return lab;
        }
        private void LabeDown(Label labe)
        {
            labe.Top += 2;
            if (labe.Top >= panel1.Height - 30)
            {
                GolbalTimer.Stop();
                LabTimerList.ForEach(item=>item.LabTimer.Stop());
                panel1.Controls.Clear();
                LabTimerList.Clear();
                MessageBox.Show("Game Over!!!");
            }
        }

    }

    public class LabeAndTimer
    {
        public Label Lab {  get; set; }
        public System.Windows.Forms.Timer LabTimer {  get; set; }
        public LabeAndTimer(Label la, System.Windows.Forms.Timer tm)
        {
            Lab = la;
            LabTimer= tm;
        }
    }
}
