using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    class Program
    {
        private const string _ipAddress = "127.0.0.1";
        private const int port = 8080;

        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse(_ipAddress);
            var serverListener = new TcpListener(ipAddress, port);

            serverListener.Start();

            Console.WriteLine("Server started on port: {0}", port);
            Console.WriteLine("Server listening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();
                var text = "Hello from the Server!";

                int bytesCount = Encoding.UTF8.GetByteCount(text);

                //                var response =
                //                    $@"HTTP/1.1 200 OK
                //Content-Type: text/plain; charset=UTF-8
                //Content-Length: {bytesCount}

                //{text}";

                string response =
                    String.Format(
                        "HTTP/1.1 200 OK \n" +
                        "Content-Type: text/plain; charset=UTF-8 \n" +
                        "Content-Length: {0} \n" +
                        "\n" +
                        "{1}", bytesCount, text);

                byte[] responeInBytes = Encoding.UTF8.GetBytes(response);

                networkStream.Write(responeInBytes);

                connection.Close();
            }
        }
    }
}
