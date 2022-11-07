using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpChatServer
{
    class Program
    {
        class TcpClientAccept
        {
            TcpListener server;
             
            Task task;

            public static List<TcpClient> clients = new List<TcpClient>();

            public Task Task { get => task; set => task = value; }

            public TcpClientAccept(TcpListener tcpListener)
            {
                this.server = tcpListener;
            }

            public void CallBack()
            {
                Byte[] bytes = new byte[1024]; //수신용버퍼

                bool isLoop = true;

                Console.Write("Waiting for a connection... ");
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Console.WriteLine("Connected!");
                NetworkStream networkStream = client.GetStream();
                while (isLoop)
                {
                    int i = networkStream.Read(bytes, 0, bytes.Length);
                    Console.WriteLine("Listening!:" + i);
                    string msg = null;

                    //while( i != 0)
                    {
                        msg = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                        Console.WriteLine("Received:" + msg);
                        if (msg == "exit")
                            break;
                        //msg = msg.ToUpper()

                        byte[] sendmsg = System.Text.Encoding.UTF8.GetBytes(msg);
                        networkStream.Write(sendmsg, 0, sendmsg.Length);
                        Console.WriteLine("Sent:" + msg);
                        //
                    }
                }
                networkStream.Close();
                client.Close();
                tasks.Remove(Task);
                Console.WriteLine("Disconnect!:"+tasks.Count);
            }
        }
        static List<Task> tasks = new List<Task>();

        static void AccptCallBack(TcpListener server)
        {
            if (TcpClientAccept.clients.Count == tasks.Count)
            {
                Console.WriteLine("Accept/Connet Count:{0}/{1}",
                    tasks.Count, TcpClientAccept.clients.Count);
                TcpClientAccept tcpClientAccept = new TcpClientAccept(server);
                Task taskClientAccept = new Task(tcpClientAccept.CallBack);
                tcpClientAccept.Task = taskClientAccept;
                taskClientAccept.Start();
                tasks.Add(taskClientAccept);
            }
        }

        static void Main(string[] args)
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = null;
            server = new TcpListener(localAddr, port);
            server.Start();

            Task taskAcceptCallBack = new Task(() => AccptCallBack(server));
            taskAcceptCallBack.Start();

            Byte[] bytes = new byte[1024]; //수신용버퍼
            do
            {
                string input = Console.ReadLine();
                if(input  == "exit")
                {
                    taskAcceptCallBack.Wait();
                }
            } while (tasks.Count > 0);
            Console.WriteLine("WaitAccept!");
  
            foreach(Task task in tasks)
            {
                task.Wait();
            }
            //networkStream.Close();
            //client.Close();
            server.Stop();
        }
    }
}
