using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_APP
{
    class Client
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket _socketClient;

        public Client(string ip, int port)
        {
            host = Dns.GetHostByName(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr, port);

            _socketClient = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
         
        }

        public void start() {
            _socketClient.Connect(endPoint);
        }

        public void Send(string msg)
        {
            byte[] byteMesg = Encoding.ASCII.GetBytes(msg);
            _socketClient.Send(byteMesg);
            Console.WriteLine("Mensaje Enviado");
            Console.ReadKey();
        }
    }
}
