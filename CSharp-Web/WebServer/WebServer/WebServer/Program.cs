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

        private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";

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
                .MapGet<HomeController>("/Login", c => c.Login())
                .MapPost<HomeController>("/Login", c => c.LoginPost())
                .MapGet<HomeController>("/Logout", c => c.LogOut());
        }

        private static void LogOutAction(Request request, Response response)
        {
            request.Session.Clear();

            response.Body = "<h3>Logged out successfully!";
        }

        private static void AddCookiesAction(
            Request request,
            Response response)
        {
            bool requestHasCookies = request.Cookies
                .Any(c => c.Name != Session.SessionCookieName);
            string bodyText = "";

            if (requestHasCookies)
            {
                StringBuilder cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText
                    .Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");

                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "<h1>Cookies set!</h1>";

                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
            }

            response.Body = bodyText;
        }


        private static void LoginAction(Request request, Response response)
        {
            //request.Session.Clear();

            string bodyText = "";

            bool loginAuth =
                request.Form["Username"] == Program.UserName &&
                request.Form["Password"] == Program.UserPass;

            if (loginAuth)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h3>Logged successfully!</h3>";
            }
            else
            {
                bodyText = Program.LoginForm;
            }

            response.Body = bodyText;
        }

        private static ConsoleAndFileLogger InitHybridLogger()
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();

            FIleLogger fileLogger = new FIleLogger("../../../loggerInfo.txt");

            return new ConsoleAndFileLogger(consoleLogger, fileLogger);
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

        private static void DisplaySessionAction(
            Request request, Response response)
        {
            bool requestHasSession = request.Session
                .ContainsKey(Session.SessionCurrentDateKey);

            string bodyText = "";

            if (requestHasSession)
            {
                string currentDate = request.Session[Session.SessionCurrentDateKey];
                bodyText += $"Stored date: {currentDate} \r\n";
                bodyText += $"Logged {request.Session.LoggedTimes} times \r\n";
            }
            else
            {
                bodyText += "Current date stored! \r\n";
                bodyText += $"Logged 1 times \r\n";
            }

            response.Body = "";
            response.Body += bodyText;
        }
    }
}
