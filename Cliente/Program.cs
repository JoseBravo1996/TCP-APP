using System;
using TCP_APP;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Client _client = new Client("localhost", 4400);
            _client.start();
            string msg;
            while (true)
            {
                Console.WriteLine("Ingrese el mensaje: ");
                msg = Console.ReadLine();
                _client.Send(msg);
            }
            Console.ReadKey();
        }
    }
}
