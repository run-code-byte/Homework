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
    public partial class MyTcpServer : Form
    {
        public MyTcpServer()
        {
            InitializeComponent();
            this.Shown += TcpSeverInit;
        }

        private void TcpSeverInit(object? sender, EventArgs e)
        {
            new MyTcpClient().Show();
            button1.Click += CreateServerAndRead;
            button2.Click += SendData;

            button2.Enabled = false;
            textBox2.Enabled = false;
        }

        private async void SendData(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                MessageBox.Show("还没客户端连接");
                return;
            }
            if (Stream == null)
            {
                IsConnected = false;
                MessageBox.Show("还没数据流");
                return;
            }
            string SendStr = textBox2.Text;
            byte[] Buffer=Encoding.UTF8.GetBytes(SendStr);
            try
            {
                await Stream.WriteAsync(Buffer, 0, Buffer.Length);
            }
            catch (Exception ex)
            {
                IsConnected=false;
                MessageBox.Show($"给客户端发消息出错：{ex.Message}");
                
            }
            textBox2.Text = "";
        }

        private TcpListener TcpServer;
        private TcpClient TCPClient;
        NetworkStream Stream;
        private bool IsConnected;
        private int num = 0;
        private async void CreateServerAndRead(object? sender, EventArgs e)
        {
            if(!int.TryParse(textBox1.Text, out int Port)||Port<0&&Port>65535)
            {
                MessageBox.Show("请输入正确的端口号");
                return;
            }
            TcpServer = new TcpListener(IPAddress.Any, Port);
            TcpServer.Start();
            Console.WriteLine("=======TCP服务启动成功=======");
            IsConnected = true;
            try
            {
                TCPClient = await TcpServer.AcceptTcpClientAsync();
                Console.WriteLine($"有客户端连接，IP是：{TCPClient.Client.RemoteEndPoint}");
                Stream=TCPClient.GetStream();

            }
            catch (Exception ex)
            {
                TcpServer.Stop();
                TcpServer?.Dispose();
                IsConnected = false;
                Console.WriteLine("====TCP服务器关闭=====");
            }

            ReadData();
            button2.Enabled = true;
            textBox2.Enabled = true;
            button1.Enabled = false;
        }

        private async void ReadData()
        {
            if (!IsConnected)
            {
                MessageBox.Show("还没客户端连接");
                return;
            }
            if (Stream == null)
            {
                IsConnected= false;
                MessageBox.Show("还没数据流");
                return;
            }

            byte[] Buffer = new byte[1024];
            while (true)
            {
                Buffer = new byte[1024];
                int Len = await Stream.ReadAsync(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    MessageBox.Show("客户端连接断开");
                    break;
                }
                string ReviceData= Encoding.UTF8.GetString(Buffer);
                Label lab=new Label();
                lab.Text= ReviceData;
                lab.Size = new Size(300, 30);
                lab.AutoSize = false;
                lab.Location = new Point(0, num * 30);
                num++;
                panel1.Controls.Add(lab);

            }
        }
    }
}
