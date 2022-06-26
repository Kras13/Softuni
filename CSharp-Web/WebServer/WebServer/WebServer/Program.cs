using SimpleWebServer;
using SimpleWebServer.ConsoleApp;
using SimpleWebServer.Server.HTTP;
using SimpleWebServer.Server.HTTP.Routing;
using SimpleWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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

        private const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

        private const string FileName = "content.txt";

        private const string _ipAddress = "127.0.0.1";
        private const int port = 8080;

        static async Task Main(string[] args)
        {
            ConsoleAndFileLogger hybridLogger = InitHybridLogger();

            try
            {
                await DownloadSiteAsTextFile(Program.FileName, new string[] { "https://judge.softuni.org/", "https://softuni.org/" });

                await Task.Run(async () =>
                {
                    var server = new HttpServer(
                     _ipAddress,
                     port,
                     hybridLogger,
                     routes => AddRoutes(routes));

                    await server.Start();
                });
            }
            finally
            {
                hybridLogger.Flush();
            }
        }

        private static ConsoleAndFileLogger InitHybridLogger()
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();

            FIleLogger fileLogger = new FIleLogger("../../../loggerInfo.txt");

            return new ConsoleAndFileLogger(consoleLogger, fileLogger);
        }

        private static void AddRoutes(IRoutingTable routes)
        {
            routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse(Program.HtmlForm))
                .MapPost("/HTML", new HtmlResponse("", Program.AddFormDataAction))
                .MapGet("/Content", new HtmlResponse(Program.DownloadForm))
                .MapPost("/Content", new TextFileResponse(Program.FileName))
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

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            HttpClient client = new HttpClient();

            using (client)
            {
                HttpResponseMessage response = await client.GetAsync(url);

                string html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

        private static async Task DownloadSiteAsTextFile(string fileName, string[] urls)
        {
            List<Task<string>> downloads = new List<Task<string>>();

            foreach (string url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            string responsesString = string.Join(
                Environment.NewLine + 
                new string('-', 100) + Environment.NewLine, responses);

            await File.WriteAllTextAsync(fileName, responsesString);
        }
    }
}
