using SimpleWebServer;
using SimpleWebServer.Server.HTTP;
using SimpleWebServer.Server.HTTP.Routing;
using SimpleWebServer.Server.Responses;
using System;
using System.Text;
using System.Threading.Tasks;

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

        static async Task Main(string[] args)
        {
            await Task.Run(async () =>
           {
               var server = new HttpServer(
                _ipAddress,
                port,
                new ConsoleLogger(),
                routes => AddRoutes(routes));

               await server.Start();
           });
        }

        private static void AddRoutes(IRoutingTable routes)
        {
            routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse(Program.HtmlForm))
                .MapPost("/HTML", new HtmlResponse("", Program.AddFormDataAction))
                .MapGet("/Redirect", new RedirectResponse("https://mobile.bg"));
        }

        private static void AddFormDataAction(Request request, Response response)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1>This is prerendered response action</h1>");
            sb.AppendLine();

            foreach (var (key, value) in request.Form)
            {
                sb.AppendLine($"{key} - {value}");
            }

            response.Body = sb.ToString();
        }
    }
}
