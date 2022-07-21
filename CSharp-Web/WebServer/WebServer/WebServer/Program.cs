using SWS;
using SWS.ConsoleApp;
using SWS.Framework.Controller;
using SWS.Server.HTTP;
using SWS.Server.HTTP.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SWS.Framework.Routing;

namespace WebServer
{
    class Program
    {
        private const string _ipAddress = "127.0.0.1";
        private const int port = 8080;

        private const string FileName = "content.txt";

        private const string UserName = "user";
        private const string UserPass = "user123";

        static async Task Main(string[] args)
        {
            //await DownloadSiteAsTextFile(
            //    Program.FileName,
            //    new string[] { "https://judge.softuni.org/", "https://softuni.org/" });

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
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                .MapGet<HomeController>("/HTML", c => c.Html())
                .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                .MapGet<HomeController>("/Content", c => c.Content())
                .MapPost<HomeController>("/Content", c => c.DownloadContent())
                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                .MapGet<HomeController>("/Session", c => c.Session())
                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                .MapGet<UsersController>("/Login", c => c.Login())
                .MapPost<UsersController>("/Login", c => c.LoginUser())
                .MapGet<UsersController>("/Logout", c => c.LogOut());
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
