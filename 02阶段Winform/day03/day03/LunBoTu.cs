using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day03
{
    public partial class LunBoTu : Form
    {
        private string[] picArr = { @"./images/cat.jpg", @"./images/bird.jpg", @"./images/eagle.jpg" };
        private int index = 0;
        private List<Button> btnList = new();
        public LunBoTu()
        {
            InitializeComponent();
            InitLunBoTu();
        }
        private void InitLunBoTu()
        {
            btnList.AddRange(button1, button2, button3);
            Label[] las = [label1, label2];

            foreach (Label label in las) label.Click += Label_Click;
            foreach (Button btn in btnList) btn.Click += Btn_Click;
            LunBo();
        }
        

        private void Btn_Click(object sender, EventArgs e)
        {
            //Button btn = (sender as Button);
            //int i = btnList.IndexOf(btn);
            index = btnList.IndexOf(sender as Button);
            LunBo();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label lab = (sender as Label);
            if (lab.Text == ">")
            {
                index = index == picArr.Length - 1 ? 0 : (++index);
                //pictureBox1.Image = Image.FromFile(picArr[index]);
                //btnList.ForEach(btn =>
                //{
                //    btn.BackColor = Color.DarkGray;
                //    btn.ForeColor = Color.Black;
                //});
                //btnList[index].BackColor = Color.Orange;
                //btnList[index].ForeColor = Color.White;

            }
            else {
                index = index == 0 ? picArr.Length - 1 :(--index);
                //pictureBox1.Image = Image.FromFile(picArr[index]);
                //btnList.ForEach(btn =>
                //{
                //    btn.BackColor = Color.DarkGray;
                //    btn.ForeColor = Color.Black;
                //});
                //btnList[index].BackColor = Color.Orange;
                //btnList[index].ForeColor = Color.White;
            }
           LunBo();
        }
        private void LunBo()
        {
            pictureBox1.Image = Image.FromFile(picArr[index]);
            btnList.ForEach(btn =>
            {
                btn.BackColor = Color.DarkGray;
                btn.ForeColor = Color.Black;
            });
            btnList[index].BackColor = Color.Orange;
            btnList[index].ForeColor = Color.White;
        }
    }
}
