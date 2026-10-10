using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
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
    public partial class Form5PMA : Form
    {
        public Form5PMA()
        {
            InitializeComponent();
            this.Shown += Form5PMA_Shown;
            this.FormClosed += Form5PMA_FormClosed;
        }
        private CogPMAlignTool PMA;
        private CogImageConvertTool CICT;
        private void Form5PMA_Shown(object sender, EventArgs e)
        {
            CICT = new CogImageConvertTool();
            PMA = new CogPMAlignTool();
           
        }

        private void Form5PMA_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private ICogAcqFifo Acq { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
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
                CICT.InputImage = Img;
                CICT.Run();
                PMA.InputImage = CICT.OutputImage;
                cogRecordDisplay1.Image = Img;
                cogRecordDisplay1.Fit();
            }
            else
            {
                Console.WriteLine("没有取到图像");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acq.StartAcquire();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetTrainImage();
        }
        private void GetTrainImage()
        {
            PMA.Pattern.TrainImage = CICT.OutputImage;
            cogRecordDisplay1.Record = PMA.CreateCurrentRecord();
            Console.WriteLine("抓取训练图像成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CogCircle Sharper = new CogCircle();
            Sharper.Interactive = true;
            Sharper.GraphicDOFEnable = CogCircleDOFConstants.All;
            PMA.Pattern.TrainRegion = Sharper;
            Console.WriteLine("设置区域形状成功");
            GetTrainImage();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            CogTransform2DLinear Origin = new CogTransform2DLinear();
            Origin.TranslationX = (PMA.Pattern.TrainRegion as CogCircle).CenterX;
            Origin.TranslationY = (PMA.Pattern.TrainRegion as CogCircle).CenterY;
            PMA.Pattern.Origin = Origin;
            Console.WriteLine("设置中心原点成功");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PMA.RunParams.ApproximateNumberToFind = 6;
            PMA.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
            PMA.RunParams.ZoneAngle.Low = -180;
            PMA.RunParams.ZoneAngle.High = 180;

            PMA.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
            PMA.RunParams.ZoneScale.Low = 0.8;
            PMA.RunParams.ZoneScale.High = 1.2;
            Console.WriteLine("设置运行参数成功");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            PMA.Pattern.Train();
            Console.WriteLine("模版训练成功");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CogGraphicCollection JX = PMA.Pattern.CreateGraphicsFine(CogColorConstants.Red);
            foreach (ICogGraphic item in JX)
            {
                cogRecordDisplay1.StaticGraphics.Add(item, "精细1");
            }
            Console.WriteLine("显示精细成功");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PMA.Run();
            cogRecordDisplay1.Record = PMA.CreateLastRunRecord();
            Console.WriteLine("工具检测结果数："+ PMA.Results.Count);
        }
    }
}
