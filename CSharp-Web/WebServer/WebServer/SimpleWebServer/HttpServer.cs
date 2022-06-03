﻿using SimpleWebServer.Tools;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleWebServer
{
    public class HttpServer
    {
        private readonly IPAddress _ipAddres;
        private readonly int _port;
        private readonly TcpListener _serverListener;
        private readonly ILogger _logger;

        public HttpServer(string ipAddress, int port, ILogger logger)
        {
            this._port = port;
            this._ipAddres = IPAddress.Parse(ipAddress);
            this._logger = logger;

            _serverListener = new TcpListener(_ipAddres, port);
        }

        public void Start()
        {
            _serverListener.Start();

            _logger.LogLine(string.Format("Server started on port: {0}", _port));
            _logger.LogLine("Server listening for requests...");

            while (true)
            {
                var connection = _serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();
                var text = "Hello from the Server!";

                int bytesCount = Encoding.UTF8.GetByteCount(text);

                //                var response =
                //                    $@"HTTP/1.1 200 OK
                //Content-Type: text/plain; charset=UTF-8
                //Content-Length: {bytesCount}

                //{text}";

                string response =
                    string.Format(
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