using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.FGGigE.Implementation.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private ICogAcqFifo Acq {  get; set; }
        private void Form1_Shown(object sender, EventArgs e)
        {
            CogFrameGrabberGigEs Grabbers = new CogFrameGrabberGigEs();

            ICogFrameGrabber Grabber = Grabbers[0];
            foreach (string item in Grabber.AvailableVideoFormats)
            {
                Console.WriteLine("相机视频格式：" + item);
            }
            //CogFrameGrabbers Grabbers = new CogFrameGrabbers();   
            //foreach (ICogFrameGrabber item in Grabbers)
            //{
            //     Console.WriteLine("相机名称" + item.Name);
            //}
            Acq = Grabbers[0].CreateAcqFifo(
                //Grabber.AvailableVideoFormats[1],
                Grabber.AvailableVideoFormats[2],
                //CogAcqFifoPixelFormatConstants.Format8Grey,
                CogAcqFifoPixelFormatConstants.Format32RGB,
                0,
                true
             );

            Acq.OwnedGigEVisionTransportParams.LatencyLevel = 1;
            Acq.OwnedExposureParams.Exposure = 50;
            Console.WriteLine("相机准备OK");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cogRecordDisplay1.StartLiveDisplay(Acq);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cogRecordDisplay1.StopLiveDisplay();
        }
    }
}
