using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCP_APP
{
    class Server
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket _socketServer;
        Socket _socketClient;

        public Server(string ip, int port)
        {
            host = Dns.GetHostByName(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr, port);

            _socketServer = new Socket(ipAddr.AddressFamily,SocketType.Stream ,ProtocolType.Tcp);
            _socketServer.Bind(endPoint);
            _socketServer.Listen(5);
        }

        public void start() {
            Thread thread;
            while (true)
            {
                Console.WriteLine("Esperando conexiones");
                _socketClient = _socketServer.Accept();
                thread = new Thread(clientConnection);
                thread.Start(_socketClient);
                Console.WriteLine("Se conecto un cliente");
            }  
        }

        public void clientConnection(object obj) {
            Socket _socketClient = (Socket) obj;
            byte[] buffer;
            int endIndex;
            while (true)
            {
                buffer = new byte[1024];
                _socketClient.Receive(buffer);
                string message = Encoding.ASCII.GetString(buffer);
                endIndex = message.IndexOf('\0');
                if (endIndex > 0)
                    message = message.Substring(0, endIndex);

                Console.WriteLine("Se recibio el mensaje: " + message);
                Console.Out.Flush();
            }
        }
            
    }
}
