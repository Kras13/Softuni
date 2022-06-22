using SimpleWebServer;
using SimpleWebServer.Server.HTTP;
using SimpleWebServer.Server.HTTP.Routing;
using SimpleWebServer.Server.Responses;
using System;

namespace WebServer
{
    class Program
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

        private const string _ipAddress = "127.0.0.1";
        private const int port = 8080;

        static void Main(string[] args)
        {
            var server = new HttpServer(
                _ipAddress,
                port,
                new ConsoleLogger(),
                routes => AddRoutes(routes));

            server.Start();
        }

        private static void AddRoutes(IRoutingTable routes)
        {
            routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse(Program.HtmlForm))
                .MapPost("/HTML", new TextResponse("", Program.AddFormDataAction))
                .MapGet("/Redirect", new RedirectResponse("https://mobile.bg"));
        }
    }
}
