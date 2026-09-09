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
            button2.Click += SendData;
            button3.Click += DisConnect;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void DisConnect(object? sender, EventArgs e)
        {
            if (!IsConnected)
            {
                MessageBox.Show("没有连接");
                IsConnected = false;
                return;
            }
            if (Stream == null)
            {
                MessageBox.Show("没有数据流");
                IsConnected = false;
                return;
            }
            // 关闭连接
            TCPClient.Close();
            IsConnected = false;
            TCPClient = null;
            Stream = null;
            button3.Enabled = true;

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
            string SendStr = textBox3.Text;
            byte[] Buffer = Encoding.UTF8.GetBytes(SendStr);
            try
            {
                await Stream.WriteAsync(Buffer, 0, Buffer.Length);
            }
            catch (Exception ex)
            {
                IsConnected = false;
                MessageBox.Show($"给客户端发消息出错：{ex.Message}");

            }
            textBox2.Text = "";
        }

        private TcpClient TCPClient;
        private bool IsConnected;
        private NetworkStream Stream;
        private int num = 0;
        private async void ConnectServerAndRead(object sender, EventArgs e)
        {
            bool isAddress = IPAddress.TryParse(textBox1.Text, out IPAddress Ip);
            bool isPort = int.TryParse(textBox2.Text, out int Port) && Port >= 0 && Port <= 65535;
            if (!isAddress && !isPort)
            {
                MessageBox.Show("输入的ip或端口号有误！！！");
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
            button3.Enabled = true;
            byte[] Buffer = new byte[1024];
            while (true)
            {
                Buffer = new byte[1024];
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
                lab.Location = new Point(0, num * 30);
                num++;
                panel1.Controls.Add(lab);

            }
        }

        
    }
}
