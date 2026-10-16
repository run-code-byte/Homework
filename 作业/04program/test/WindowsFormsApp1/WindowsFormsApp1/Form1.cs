using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.ToolBlock;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
        }
        private NetworkStream Stream { get; set; }  // TCP 数据流(与机械臂通信)
        private ICogAcqFifo Acq { get; set; }       // 相机采集 FIFO
        private CogToolBlock CTB { get; set; }      // 视觉检测方案(ToolBlock)
        private IModbusMaster master;               // Modbus 主站(控制传送带)
        private ushort IsGo = 0;                    // 传送带开关状态 0停 1启
        private void button38_Click(object sender, EventArgs e)
        {
           

            // 加载相机==> 取像队列对象
            ICogFrameGrabber Grabber = new CogFrameGrabberGigEs()[0];
            Acq = Grabber.CreateAcqFifo(
                 Grabber.AvailableVideoFormats[1],
                 CogAcqFifoPixelFormatConstants.Format8Grey,
                 0,
                 true
            );
            Acq.OwnedGigEVisionTransportParams.LatencyLevel = 1;
            Acq.OwnedExposureParams.Exposure = 50;
            Acq.Complete += Acq_Complete; // 开始取像事件
            Console.WriteLine("相机加载成功");
            
        }
        private void Acq_Complete(object sender, CogCompleteEventArgs e)
        {
            // 取像
            Acq.GetFifoState(out int _, out int Num, out var _);
            if (Num > 0)
            {
                //ICogImage Img = Acq.CompleteAcquireEx(new CogAcqInfo());
                //CTB.Inputs["InputImage"].Value = Img;
                //// 开始检测===>执行CTB
                //CTB.Run();
                //Console.WriteLine("检测个数: " + CTB.Outputs["Count"].Value);
                //cogRecordDisplay1.Image = Img;
                //cogRecordDisplay1.Fit();

                // 将CTB 运行的结果记录 给到控件展示
                //cogRecordDisplay1.Record = CTB.CreateLastRunRecord();
                //CTB.CreateLastRunRecord().SubRecords; // 获取所有的结果记录
                // [1] 表示第二个工具的运行结果记录
                //cogRecordDisplay1.Record = CTB.CreateLastRunRecord().SubRecords[1];
                // 也可以通过 方案中的 结果图 展示
                cogRecordDisplay1.Record = CTB.CreateLastRunRecord().SubRecords["CogImageConvertTool1.OutputImage"];
            }
            else
            {
                Console.WriteLine("没有取到图像");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Acq.StartAcquire();// 开始取像
            Console.WriteLine("取像开始");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        {
            // 加载检测方案
            CTB = CogSerializer.LoadObjectFromFile("./vpps/瓶盖检测new.vpp") as CogToolBlock;
            Console.WriteLine("检测方案加载成功");
        }

        private void button45_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            try
            {
                if (Acq != null)
                {
                    // 1. 解绑Complete事件，防止后台事件继续回调
                    Acq.Complete -= Acq_Complete;

                    // 2. 清空FIFO，停止采集任务，丢弃队列里残留图片
                    Acq.Flush();

                  
                    Acq = null;
                }

                // 清空图像显示控件
                cogRecordDisplay1.Record = null;
                cogRecordDisplay1.Image = null;

                Console.WriteLine("相机断开成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"相机断开异常：{ex.Message}");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {

        }
    }
}
