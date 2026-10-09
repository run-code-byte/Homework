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
    public partial class Form4Run : Form
    {
        public Form4Run()
        {
            InitializeComponent();
            this.Shown += Form4Run_Shown;
            this.FormClosed += Form4Run_FormClosed;
        }

        private void Form4Run_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private CogToolBlock CTB { get; set; }
        private ICogAcqFifo Acq { get; set; }
        private CogAcqFifoTool InnerAcq;
        private void Form4Run_Shown(object sender, EventArgs e)
        {
            CTB = CogSerializer.LoadObjectFromFile("./vpps/new瓶盖计数带相机.vpp") as CogToolBlock;
            Console.WriteLine("检测方案加载成功");
            InnerAcq = CTB.Tools["CogAcqFifoTool1"] as CogAcqFifoTool;

            ICogFrameGrabber Grabber = new CogFrameGrabberGigEs()[0];
            Acq = Grabber.CreateAcqFifo(
                Grabber.AvailableVideoFormats[1],
                CogAcqFifoPixelFormatConstants.Format8Grey,
                0,
                true
             );
            Acq.OwnedGigEVisionTransportParams.LatencyLevel = 1;
            Acq.OwnedExposureParams.Exposure = 50;

            Acq.OwnedTriggerParams.TriggerEnabled = true;
            Acq.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Auto;

            InnerAcq.Operator = Acq;

            Console.WriteLine("相机加载成功");
        }

        private bool isRuning = true;
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                while (isRuning)
                {
                    CTB.Run();
                    cogRecordDisplay1.Image = InnerAcq.OutputImage;
                    cogRecordDisplay1.Fit();
                    Console.WriteLine("测试结果数量：" + CTB.Outputs["Count"].Value);
                    //cogRecordDisplay1.Record = CTB.CreateLastRunRecord();
                    cogRecordDisplay1.Record = CTB.CreateLastRunRecord().SubRecords[0];
                }
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isRuning = false;
        }
    }
}
