using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpChatClient
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

        public static IPAddress GetIPAddress()
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = null;
            // 처음으로 발견되는 ipv4 주소를 사용한다.
            foreach (IPAddress addr in he.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    iPAddress = addr;
                    break;
                }
            }

            // 주소가 없다면..
            if (iPAddress == null)
                // 로컬호스트 주소를 사용한다.
                iPAddress = IPAddress.Loopback;

            return iPAddress;
        }

        static void Main(string[] args)
        {
            string ip = GetIPAddress().ToString();
            Console.WriteLine("IP:" + ip);
            SendMsg("127.0.0.1", "connect");

            while(true)
            {
                string input = Console.ReadLine();
                string msg = string.Format("{0};{1}",ip,input);
                SendMsg("192.168.1.49", msg);
            }
        }
    }
}
