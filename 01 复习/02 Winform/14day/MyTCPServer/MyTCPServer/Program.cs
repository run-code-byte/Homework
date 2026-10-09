using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyTCPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string ip = "127.0.0.1";
            IPAddress IPAddr = IPAddress.Parse(ip);
            int Port = 8080;
            TcpListener TcpServer = new TcpListener(IPAddr, Port);
            TcpServer.Start();

            TcpClient TCPClient = TcpServer.AcceptTcpClient();
            NetworkStream Stream = TCPClient.GetStream();

            byte[] Buffer = new byte[1024];
            while(true)
            {
                int BytesRead = Stream.Read(Buffer, 0, Buffer.Length);
               
                string ClientIp = TCPClient.Client.RemoteEndPoint?.ToString();
                Console.WriteLine($"有人连接： {ClientIp}");

                string ReceivedData = System.Text.Encoding.UTF8.GetString(Buffer, 0, BytesRead);
                Console.WriteLine("Received: " + ReceivedData);

                string sendStr = "OK";
                byte[] SendBuffer = Encoding.UTF8.GetBytes(sendStr);
                Stream.Write(SendBuffer, 0, SendBuffer.Length);

            }
        }
    }
}
