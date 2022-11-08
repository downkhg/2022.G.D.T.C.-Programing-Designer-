using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServer
{
    class Program
    {
        static int port = 11000;
        static void SendMsg(string ip, string strSendMsg)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Console.WriteLine("Send:" + strSendMsg);
            IPAddress broadcast = IPAddress.Parse(ip);

            byte[] sendbuf = Encoding.ASCII.GetBytes(strSendMsg);
            IPEndPoint ep = new IPEndPoint(broadcast, port);

            s.SendTo(sendbuf, ep);

            Console.WriteLine("Message sent to the broadcast address");
        }
        static void Main(string[] args)
        {
            int listenPort = 11000;
            List<string> clientIps = new List<string>();
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    string msg = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    Console.WriteLine($" {msg}");
                    
                    
                    string[] strSplit = msg.Split(';');
                    if (strSplit.Length > 0)
                    {
                        string header = strSplit[0];
                        string content = strSplit[1];
               

                        if (header == "connect")
                        {
                            clientIps.Add(content);
                            Console.WriteLine("Connect:"+ content);
                        }
                        else
                        {
                            foreach (string ip in clientIps)
                            {
                                if(ip != header) SendMsg(ip, msg);
                            }
                        }
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
