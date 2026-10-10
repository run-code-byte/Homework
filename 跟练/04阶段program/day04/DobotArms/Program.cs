using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DobotArms
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string IP = "127.0.0.1";
            
           
            TcpListener TcpServer = new TcpListener(IPAddress.Any, 8989);
            // 启动TCP服务器
            TcpServer.Start();
            Console.WriteLine( "机械臂服务端启动：等待客户端连接----");
            // 创建等待客户端对象
            TcpClient TCPClient = TcpServer.AcceptTcpClient();

            // 创建数据流(数据管道) 
            NetworkStream Stream = TCPClient.GetStream();
        
            // 创建接收数据的字节数组
            byte[] Buffer = new byte[1024];
            while (true)
            {
                int Len = Stream.Read(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    Console.WriteLine("客户端没有消息");
                    break;
                }

                // 同步阻塞代码,读取到了数据才会往下执行那个
                // 获取到连接上服务端的客户端信息
                string ClientIp = TCPClient.Client.RemoteEndPoint?.ToString();
                Console.WriteLine($"有人连接: {ClientIp}");

                // 将字节数组 转为字符串
                string ReviceData = System.Text.Encoding.UTF8.GetString(Buffer, 0, Len);
                if (ReviceData == "connect") ConnectDobot(Stream);
                else
                {
                    Dictionary<string, float> Arms = JsonSerializer.Deserialize<Dictionary<string, float>>(ReviceData)?? new Dictionary<string, float>();
                    
                    if (Arms.ContainsKey("x"))
                    {
                    PickAndPlace( Arms,Stream);

                    }
                }
                


                //// 给客户端发数据 消息
                //string sendStr = "OK";
                //// 字符串转为 字节数组 方便 数据管道发送数据
                //byte[] SendData = Encoding.UTF8.GetBytes(sendStr);
                //Stream.Write(SendData, 0, SendData.Length);

            }
        }

        static private void ConnectDobot(NetworkStream Stream)
        {
            StringBuilder fwType = new StringBuilder(128);
            StringBuilder version = new StringBuilder(128);
            int ret = DobotDll.ConnectDobot("COM3", 115200, fwType, version);
            if (ret == 0)
            {
                Console.Write($"连接成功！\n固件:{fwType}\n版本:{version}");
            }
            else
            {
                Console.Write($"连接失败，返回码:{ret}");
            }
            string sendStr = "connected";
            // 字符串转为 字节数组 方便 数据管道发送数据
            byte[] SendData = Encoding.UTF8.GetBytes(sendStr);
            Stream.Write(SendData, 0, SendData.Length);
        }
        static private void PickAndPlace(Dictionary<string, float> Arms,NetworkStream Stream)
        {
            // 取料位置 上方
            PTPCmd ptp1 = new PTPCmd();
            ptp1.ptpMode = 1;
            ptp1.x = Arms["x"];
            ptp1.y = Arms["y"];
            ptp1.z = (float)80;
            ptp1.rHead = (float)0;
            UInt64 cmdIndex1 = 1;
            DobotDll.SetPTPCmd(ref ptp1, true, ref cmdIndex1);

            // 取料位置 
            PTPCmd ptp2 = new PTPCmd();
            ptp2.ptpMode = 1;
            ptp2.x = Arms["x"];
            ptp2.y = Arms["y"];
            ptp2.z = (float)-18;
            ptp2.rHead = (float)0;
            UInt64 cmdIndex2 = 2;
            DobotDll.SetPTPCmd(ref ptp2, true, ref cmdIndex2);

            UInt64 cmdIndex3 = 3;
            DobotDll.SetEndEffectorSuctionCup(true, true, true, ref cmdIndex3);

            PTPCmd ptp4 = new PTPCmd();
            ptp4.ptpMode = 1;
            ptp4.x = Arms["x"];
            ptp4.y = Arms["y"];
            ptp4.z = (float)80;
            ptp4.rHead = (float)0;
            UInt64 cmdIndex4 = 4;
            DobotDll.SetPTPCmd(ref ptp4, true, ref cmdIndex4);

            PTPCmd ptp5 = new PTPCmd();
            ptp5.ptpMode = 1;
            ptp5.x = (float)8;
            ptp5.y = (float)218;
            ptp5.z = (float)80;
            ptp5.rHead = (float)0;
            UInt64 cmdIndex5 = 5;
            DobotDll.SetPTPCmd(ref ptp5, true, ref cmdIndex5);

            UInt64 cmdIndex6 = 6;
            DobotDll.SetEndEffectorSuctionCup(true, false, true, ref cmdIndex6);

            // 启动队列
            int ret = DobotDll.SetQueuedCmdStartExec();
            if (ret == 0) Console.WriteLine("队列开始执行，机械臂自动跑点位");
            else Console.WriteLine($"启动队列失败，返回码:{ret}");

            // 等待整套动作跑完，预估5秒，延时7秒保险
            Console.WriteLine("等待机械臂执行动作...");
            Thread.Sleep(7000);
            Console.WriteLine("全部动作执行完成！");

            // 跑完之后清空队列、停止队列
            DobotDll.SetQueuedCmdClear();
            DobotDll.SetQueuedCmdStopExec();
            Console.WriteLine("队列已清空并停止");

        }

    }
}
