using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.ToolBlock;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InspectProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private NetworkStream Stream; // TCP 数据流(与机械臂通信)
        private ICogAcqFifo Acq { get; set; }       // 相机采集 FIFO
        private CogToolBlock CTB { get; set; }      // 视觉检测方案(ToolBlock)
        //private IModbusMaster master;               // Modbus 主站(控制传送带)
        private ushort IsGo = 0;                    // 传送带开关状态 0停 1启
        private void button1_Click(object sender, EventArgs e)
        {
            // 创建tcp客户端
            TcpClient TCPClient = new TcpClient();
            // 连接，参数1：ip地址(IPAddress)   参数2：端口号(int)
            TCPClient.Connect(IPAddress.Parse("127.0.0.1"), 8989);
            // 创建数据流
            Stream = TCPClient.GetStream();

            // 发送数据
            // 转成字节数组
            byte[] SendBytes = System.Text.Encoding.UTF8.GetBytes("connect");
            // 发送数据
            Stream.Write(SendBytes, 0, SendBytes.Length);

            Task.Run(new Action(async () => { ReadData(); })); // 后台监听
        }

        private void ReadData()
        {
            byte[] Buffer = new byte[1024];
            while (true)
            {
                int Len = Stream.Read(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    Console.WriteLine("没有消息--");
                    break;
                }
                string ReviceData = System.Text.Encoding.UTF8.GetString(Buffer, 0, Len);
                Console.WriteLine(ReviceData);
                if (ReviceData=="connected") Console.WriteLine("机械臂连接成功");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, float> Arms = new Dictionary<string, float>
            {
                ["x"] = (float)280,
                ["y"] = (float)-25,
            };
            string sendData = JsonConvert.SerializeObject(Arms);

            byte[] SendBytes = System.Text.Encoding.UTF8.GetBytes(sendData);
            // 发送数据
            Stream.Write(SendBytes, 0, SendBytes.Length);
            Console.WriteLine("机械臂运动测试--");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ICogFrameGrabber Grabber =  new CogFrameGrabberGigEs()[0];
            Acq = Grabber.CreateAcqFifo(
                Grabber.AvailableVideoFormats[1],
                CogAcqFifoPixelFormatConstants.Format8Grey,
                0,
                true
             );
            Acq.OwnedExposureParams.Exposure = 50;
            Acq.OwnedGigEVisionTransportParams.LatencyLevel = 1;
            Acq.OwnedTriggerParams.TriggerEnabled = true;
            Acq.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Auto;
            Acq.Complete += Acq_Complete;
            Console.WriteLine("相机加载成功");

        }

        private void Acq_Complete(object sender, CogCompleteEventArgs e)
        {
            Acq.GetFifoState(out int _, out int Num, out bool _);
            if (Num > 0)
            {
                ICogImage Img = Acq.CompleteAcquireEx(new CogAcqInfo());
                cogRecordDisplay1.Image = Img;
                Console.WriteLine("采集图像成功");
            }
            else
            {
                Console.WriteLine("没有图像");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CTB = CogSerializer.LoadObjectFromFile("./vpps/瓶盖检测.vpp") as CogToolBlock;
            Console.WriteLine("检测方案加载成功");
        }
    }
}
