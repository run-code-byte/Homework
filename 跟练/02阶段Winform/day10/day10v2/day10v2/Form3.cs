using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day10v2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            MyTimer2.Interval = 1000;
            MyTimer2.Tick += MyTimer2_Tick;
            MyTimer2.Start();
        }

        private void MyTimer2_Tick(object sender, EventArgs e)
        {
            ShowDateTimeLabel();
            ShowNowTimePic();
            ShowNationalDayCountDown();
        }

        /// <summary>
        /// label1 显示当前年月日
        /// </summary>
        private void ShowDateTimeLabel()
        {
            DateTime now = DateTime.Now;
            label1.Text = now.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// pictureBox1~8：当前时分秒 HH:mm:ss
        /// 1,2=小时；3=冒号；4,5=分钟；6=冒号；7,8=秒
        /// </summary>
        private void ShowNowTimePic()
        {
            DateTime dt = DateTime.Now;
            string hh = dt.Hour.ToString("D2");
            string mm = dt.Minute.ToString("D2");
            string ss = dt.Second.ToString("D2");

            // 冒号
            SetPicColon(pictureBox3);
            SetPicColon(pictureBox6);

            PictureBox[] nowPics = { pictureBox1, pictureBox2, pictureBox4, pictureBox5, pictureBox7, pictureBox8 };
            string timeStr = hh + mm + ss;
            for (int i = 0; i < nowPics.Length; i++)
            {
                SetPicNumber(nowPics[i], timeStr[i]);
            }
        }

        /// <summary>
        /// pictureBox9‑19：国庆倒计时 DD天HH:mm:ss
        /// 9,10=天数；11=天字占位；12,13=小时；14=冒号；15,16=分钟；17=冒号；18,19=秒
        /// </summary>
        private void ShowNationalDayCountDown()
        {
            DateTime nationalDay = new DateTime(2026, 10, 1, 0, 0, 0);
            DateTime now = DateTime.Now;

            if (now >= nationalDay)
            {
                // 已到国庆全部归零
                SetPicNumber(pictureBox9, '0');
                SetPicNumber(pictureBox10, '0');
                // pictureBox11你可以放"天"的图片
                SetPicNumber(pictureBox12, '0');
                SetPicNumber(pictureBox13, '0');
                SetPicColon(pictureBox14);
                SetPicNumber(pictureBox15, '0');
                SetPicNumber(pictureBox16, '0');
                SetPicColon(pictureBox17);
                SetPicNumber(pictureBox18, '0');
                SetPicNumber(pictureBox19, '0');
                return;
            }

            TimeSpan ts = nationalDay - now;
            string dayStr = ts.Days.ToString("D2");
            string hourStr = ts.Hours.ToString("D2");
            string minStr = ts.Minutes.ToString("D2");
            string secStr = ts.Seconds.ToString("D2");

            SetPicNumber(pictureBox9, dayStr[0]);
            SetPicNumber(pictureBox10, dayStr[1]);
            // pictureBox11：这里如果有"天.png"就写 SetPicText(pictureBox11,"天");

            SetPicNumber(pictureBox12, hourStr[0]);
            SetPicNumber(pictureBox13, hourStr[1]);
            SetPicColon(pictureBox14);

            SetPicNumber(pictureBox15, minStr[0]);
            SetPicNumber(pictureBox16, minStr[1]);
            SetPicColon(pictureBox17);

            SetPicNumber(pictureBox18, secStr[0]);
            SetPicNumber(pictureBox19, secStr[1]);
        }

        /// <summary>
        /// 加载数字图片
        /// </summary>
        private void SetPicNumber(PictureBox pic, char numChar)
        {
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = Image.FromFile($@"./images/{numChar}.png");
        }

        /// <summary>
        /// 加载冒号图片 maohao.png
        /// </summary>
        private void SetPicColon(PictureBox pic)
        {
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = Image.FromFile(@"./images/maohao.png");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MyTimer2.Stop();
            base.OnFormClosing(e);
        }
    }
}
