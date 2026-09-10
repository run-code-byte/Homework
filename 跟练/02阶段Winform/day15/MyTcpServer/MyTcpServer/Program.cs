using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace MyTcpServer
{
    internal class Program
    {
        private static List<TcpClient> ClientList = new();
        static async Task Main(string[] args)
        {
            var TcpServer = new TcpListener(IPAddress.Any, 8090);
            TcpServer.Start();
            while (true)
            {
                try
                {
                    TcpClient TClient = await TcpServer.AcceptTcpClientAsync();
                    ClientList.Add(TClient);
                    Console.WriteLine(ClientList.Count);

                }
                catch (Exception err)
                {

                    Console.WriteLine($"连接错误：{err.Message}");
                }
                HandlerClient();
            }


        }

        private static async void HandlerClient()
        {
            foreach(TcpClient TClient in ClientList)
            {
                //Task.Run(()=>HandlerMessage(TClient));
                HandlerMessage(TClient);
            }
        }
        private static async void HandlerMessage(TcpClient TClient)
        {
            NetworkStream Stream = TClient.GetStream();
            byte[] Buffer = new byte[1024];
            while (true)
            {
                int Len = await Stream.ReadAsync(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    Console.WriteLine("连接断开");
                    break;
                }
                foreach (TcpClient PClient in ClientList)
                {
                    NetworkStream PStream = PClient.GetStream();
                    await PStream.WriteAsync(Buffer, 0, Buffer.Length);

                }
            }
        }
    }
}
