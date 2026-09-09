using System.Net.Sockets;
using System.Text;

namespace WinFormsApp2
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
            TCPClient.Connect("127.0.0.1", 8888);
            Stream=TCPClient.GetStream();

            string SendStr = "你好，吃饭了么？";
            byte[] SendBytes=Encoding.UTF8.GetBytes(SendStr);
            Stream.Write(SendBytes, 0, SendBytes.Length);

            ReadData();
        }

        private void ReadData()
        {
            byte[] Buffer = new byte[1024];
            while (true)
            {
                int Len = Stream.Read(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    MessageBox.Show("连接断开");
                    break;
                }
                string ReviceStr = Encoding.UTF8.GetString(Buffer);
                MessageBox.Show(ReviceStr);
            }
        }
    }
}
