using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyTcpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += TcpClientInit;
        }
        private void TcpClientInit(object sender, EventArgs e)
        {
            // 给连接按钮和 发送消息绑定事件
            button1.Click += ConnectServerAndRead;
            button2.Click += SendData;

            // 设置UI
            button2.Enabled = false;

        }
        private async void SendData(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                MessageBox.Show("还没连接服务器");
                return;
            }
            if (Stream == null)
            {
                IsConnected = false;
                MessageBox.Show("还没数据流");
                return;
            }
            // 获取输入的数据
            string SendStr = textBox3.Text;
            // 转为字节数组
            byte[] Buffer = Encoding.UTF8.GetBytes(SendStr);
            try
            {
                // 给客户端发送数据
                await Stream.WriteAsync(Buffer, 0, Buffer.Length);
            }
            catch (Exception ex)
            {
                IsConnected = false;
                MessageBox.Show($"给客户端发消息出错: {ex.Message}");
            }
            textBox3.Text = "";
        }

        private TcpClient TCPClient;
        private bool IsConnected;
        private NetworkStream Stream;
        private int Num = 0;
        private async void ConnectServerAndRead(object sender, EventArgs e)
        {
            // 接收输入的ip及端口号 并校验
            bool isAddress = IPAddress.TryParse(textBox1.Text, out IPAddress Ip);
            bool isPort = int.TryParse(textBox2.Text, out int Port) && Port >= 0 && Port <= 65535;
            if (!isAddress || !isPort)
            {
                MessageBox.Show("输入的ip或端口号有误!!!");
                return;
            }
            // 创建 客户端
            TCPClient = new TcpClient();
            try
            {
                // 连接服务器
                await TCPClient.ConnectAsync(Ip, Port);
                Stream = TCPClient.GetStream();// 获取数据流
                IsConnected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败!!!");
                IsConnected = false;
            }

            // 读取数据(别的方法读取)
            ReadData();
        }
        private async void ReadData()
        {
            if (!IsConnected)
            {
                MessageBox.Show("还没连接服务器");
                return;
            }
            if (Stream == null)
            {
                IsConnected = false;
                MessageBox.Show("还没数据流");
                return;
            }
            button2.Enabled = true;
            button1.Enabled = false;
            // 准备字节数组 接收读取的数据
            byte[] Buffer = new byte[1024];
            while (true)
            {
                Buffer = new byte[1024];
                // 读取数据
                int Len = await Stream.ReadAsync(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    MessageBox.Show("连接断开");
                    break;
                }
                // 拿到客户端发来的数据
                string ReviceData = Encoding.UTF8.GetString(Buffer);
                // 创建Label展示 数据
                Label lab = new Label();
                lab.Text = ReviceData;
                lab.Size = new Size(300, 30);
                lab.AutoSize = false;
                lab.Location = new Point(0, Num * 30);
                Num++;
                panel1.Controls.Add(lab);
            }
        }
    }
}
