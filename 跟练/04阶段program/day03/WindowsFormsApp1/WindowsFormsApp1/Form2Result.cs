using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.ToolBlock;
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
    public partial class Form2Result : Form
    {
        public Form2Result()
        {
            InitializeComponent();
            this.Shown += Form2Result_Shown;
            this.FormClosed += Form2Result_FormClosed;
        }

        private void Form2Result_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private CogToolBlock CTB { get; set; }
        private ICogAcqFifo Acq { get; set; }

        private void Form2Result_Shown(object sender, EventArgs e)
        {
            CTB = CogSerializer.LoadObjectFromFile("./vpps/瓶盖计数.vpp") as CogToolBlock;
            Console.WriteLine("检测方案加载成功");
            ICogFrameGrabber Grabber = new CogFrameGrabberGigEs()[0];
            Acq = Grabber.CreateAcqFifo(
                Grabber.AvailableVideoFormats[1],
                CogAcqFifoPixelFormatConstants.Format8Grey,
                0,
                true
             );
            Acq.OwnedGigEVisionTransportParams.LatencyLevel = 1;
            Acq.OwnedExposureParams.Exposure = 50;
            Acq.Complete += Acq_Complete;
            Console.WriteLine("相机加载成功");
        }

        private void Acq_Complete(object sender, CogCompleteEventArgs e)
        {
            Acq.GetFifoState(out int _, out int Num, out var _);
            if (Num > 0)
            {
                ICogImage Img = Acq.CompleteAcquireEx(new CogAcqInfo());
                CTB.Inputs["InputImaage"].Value = Img;
                CTB.Run();
                Console.WriteLine("检测个数：" + CTB.Outputs["Count"].Value);
                cogRecordDisplay1.Image = Img;
                cogRecordDisplay1.Fit();
                //cogRecordDisplay1.Record = CTB.CreateCurrentRecord().SubRecords[1];
                cogRecordDisplay1.Record = CTB.CreateCurrentRecord().SubRecords["CogImageConvertTool1.OutputImae"];
            }
            else
            {
                Console.WriteLine("没有取到图像");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acq.StartAcquire();

        }
    }
}
