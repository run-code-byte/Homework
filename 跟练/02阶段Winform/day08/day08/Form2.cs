using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace day08
{
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
            this.Shown += Form2_Shown;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.autoStart = false;
            //axWindowsMediaPlayer1.PlayStateChange += AxStatusChanged;
            axWindowsMediaPlayer1.ErrorEvent += error_Start;

            axWindowsMediaPlayer1.PositionChange += AxPositionChanged;

            axWindowsMediaPlayer1.URL = @"./00-复习.mp444";
            //axWindowsMediaPlayer1.uiMode = "full"; // 隐藏控件

            sp = new SoundPlayer(@"./孤勇者.wav");
        }

        private SoundPlayer sp;
        private void error_Start(object sender, EventArgs e) // 当播放器整体发生错误时触发，例如播放路径错误
        {
            IWMPError errorObj = axWindowsMediaPlayer1.Error;
            IWMPErrorItem err = errorObj.get_Item(0);
            MessageBox.Show($"错误码：{err.errorCode}\n信息：{err.errorDescription}");
        }
        private void AxPositionChanged(object sender, _WMPOCXEvents_PositionChangeEvent e)
        {
            throw new NotImplementedException();
        }

        private void AxStatusChanged(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            MessageBox.Show(e.newState.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 70;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sp.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }
    }
}
