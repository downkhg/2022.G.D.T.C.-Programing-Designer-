using System;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverip = "127.0.0.1";
            Int32 port = 13000;
            TcpClient client = new TcpClient(serverip, port);

            bool isLoop = true;

            NetworkStream stream = client.GetStream();
            while (isLoop)
            {
                string msg = "connect";
                Console.Write("SendMsg:");
                msg = Console.ReadLine();


                Byte[] bytes = System.Text.Encoding.UTF8.GetBytes(msg);
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine("Sent:" + msg);


                if (msg == "exit")
                {
                    isLoop = false;
                    break;
                }

                bytes = new Byte[1024];

                string responserData = String.Empty;

                Int32 bytesLenth = stream.Read(bytes, 0, bytes.Length);
                responserData = System.Text.Encoding.UTF8.GetString(bytes);
                Console.WriteLine("Recive:" + responserData);
                
            }
            stream.Close();
            client.Close();
        }
    }
}
