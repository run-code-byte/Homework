using System.Net.Sockets;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }
        NetworkStream Stream;

        private void Form1_Shown(object? sender, EventArgs e)
        {
            TcpClient TCPClient = new TcpClient();
            TCPClient.Connect("127.0.0.1", 8080);
            Stream = TCPClient.GetStream();

            string sendStr = "Hello, Server!你好，世界！";
            byte[] SendBuffer = Encoding.UTF8.GetBytes(sendStr);
            Stream.Write(SendBuffer, 0, SendBuffer.Length);

            ReadData();
        }

        private void ReadData()
        {
            byte[] Buffer = new byte[1024];
            while(true)
            {
                int BytesRead = Stream.Read(Buffer, 0, Buffer.Length);
                if(BytesRead == 0)
                {
                    MessageBox.Show("Connection closed by server.连接断开");
                    break; // Connection closed
                }
                string ReceivedData = Encoding.UTF8.GetString(Buffer, 0, BytesRead);
                MessageBox.Show("Received: " + ReceivedData);
                
            }
        }
    }
}
