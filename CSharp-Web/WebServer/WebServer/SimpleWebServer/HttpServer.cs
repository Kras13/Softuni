using SimpleWebServer.Server.HTTP;
using SimpleWebServer.Server.HTTP.Routing;
using SimpleWebServer.Tools;
using System;
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

        private readonly RoutingTable routingTable;

        public HttpServer(
            string ipAddress,
            int port,
            ILogger logger,
            Action<IRoutingTable> routingTableConfiguration)
        {
            this._port = port;
            this._ipAddres = IPAddress.Parse(ipAddress);
            this._logger = logger;

            _serverListener = new TcpListener(_ipAddres, port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, ILogger logger, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, logger, routingTable)
        {

        }

        public HttpServer(ILogger logger, Action<IRoutingTable> routingTable) 
            : this(8080, logger, routingTable)
        {

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

                string requestString = ReadRequest(networkStream);

                _logger.LogLine(requestString);

                Request request = Request.Parse(requestString);

                Response response = routingTable.MatchRequest(request);

                WriteResponse(networkStream);

                connection.Close();
            }
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            int bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];

            int totalBytes = 0;

            StringBuilder sb = new StringBuilder();

            do
            {
                int bytesRead = networkStream.Read(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * bufferLength)
                {
                    throw new InvalidOperationException("Request too long!");
                }

                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return sb.ToString();
        }

        private void WriteResponse(NetworkStream networkStream)
        {
            string text = "Hello from the server!";

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
        }
    }
}
