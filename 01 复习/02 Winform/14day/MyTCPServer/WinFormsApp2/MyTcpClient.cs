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

namespace WinFormsApp2
{
    public partial class MyTcpClient : Form
    {
        public MyTcpClient()
        {
            InitializeComponent();
            this.Shown += TcpClientInit;
        }

        private void TcpClientInit(object sender, EventArgs e)
        {
            button1.Click += ConnectServerAndRead;
        }
        private TcpClient TCPClient;
        private bool IsConnected;
        private NetworkStream Stream;
        private int Num = 0;
        private async void ConnectServerAndRead(object sender, EventArgs e)
        {
            bool isAddress = IPAddress.TryParse(textBox1.Text, out IPAddress Ip);
            bool isPort = int.TryParse(textBox2.Text, out int Port) && Port < 0 && Port > 65535;
            if (isAddress|| isPort)
            {
                MessageBox.Show("请输入的IP或端客户有误！！！");
                return;
            }
            TCPClient = new TcpClient();
            try
            {
                await TCPClient.ConnectAsync(Ip, Port);
                Stream = TCPClient.GetStream();
                IsConnected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败！！！");
                IsConnected = false;
            }
            ReadData();
        }
        private async Task ReadData()
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
            byte[] Buffer = new byte[1024];
            while (true)
            {
                int Len = await Stream.ReadAsync(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    MessageBox.Show("连接断开");
                    break;
                }
                string ReviceData = Encoding.UTF8.GetString(Buffer);
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
