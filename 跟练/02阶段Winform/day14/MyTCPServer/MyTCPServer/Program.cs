using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyTCPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string IP = "127.0.0.1";
            IPAddress IPAddr=  IPAddress.Parse(IP);
            int Port = 8888;
            TcpListener TcpServer= new TcpListener(IPAddr, Port);
            TcpServer.Start();

            TcpClient TCPClient = TcpServer.AcceptTcpClient();
            NetworkStream Stream=TCPClient.GetStream();

            byte[] Buffer= new byte[1024];
            while (true)
            {
                int len = Stream.Read(Buffer, 0, Buffer.Length);

                string ClientIp = TCPClient.Client.RemoteEndPoint?.ToString();
                Console.WriteLine($"有人连接了：{ClientIp}");

                string ReviceData=System.Text.Encoding.UTF8.GetString (Buffer, 0, len);
                Console.WriteLine(ReviceData);

                

                string sendStr = "OK";
                byte[] SendData = Encoding.UTF8.GetBytes(sendStr);
                Stream.Write(SendData, 0, SendData.Length);

            }
        }
    }
}
