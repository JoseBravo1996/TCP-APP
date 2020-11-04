using System;

namespace TCP_APP
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Server _server = new Server("localhost", 4400);
            _server.start();
        }
    }
}
