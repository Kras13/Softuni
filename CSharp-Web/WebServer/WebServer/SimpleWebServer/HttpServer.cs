using SWS.Server.HTTP;
using SWS.Server.HTTP.Routing;
using SWS.Tools;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SWS
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

        public async Task Start()
        {
            _serverListener.Start();

            await _logger.LogLine(string.Format("Server started on port: {0}", _port));
            await _logger.LogLine("Server listening for requests...");

            while (true)
            {
                TcpClient tcpClient = await _serverListener.AcceptTcpClientAsync();

                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            var networkStream = tcpClient.GetStream();

            string requestString = await ReadRequest(networkStream);

            await _logger.LogLine(requestString);

            Request request = Request.Parse(requestString);

            Response response = routingTable.MatchRequest(request);

            AddSession(request, response);

            await WriteResponse(networkStream, response);

            tcpClient.Close();
        }

        private void AddSession(Request request, Response response)
        {
            bool sessionExists = request.Session
                .ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExists)
            {
                request.Session[Session.SessionCurrentDateKey] = 
                    DateTime.Now.ToString();
                response.Cookies
                    .Add(Session.SessionCookieName, request.Session.Id);
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            int bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];

            int totalBytes = 0;

            StringBuilder sb = new StringBuilder();

            do
            {
                int bytesRead =
                    await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * bufferLength)
                {
                    throw new InvalidOperationException("Request too long!");
                }

                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return sb.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            byte[] responseInBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseInBytes);
        }
    }
}
