using SimpleWebServer;
using System;

namespace WebServer
{
    class Program
    {
        private const string _ipAddress = "127.0.0.1";
        private const int port = 8080;

        static void Main(string[] args)
        {
            var server = new HttpServer(_ipAddress, port, new ConsoleLogger());

            server.Start();
        }
    }
}
