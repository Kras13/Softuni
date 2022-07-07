using SWS;
using SWS.ConsoleApp;
using SWS.Server.HTTP;
using SWS.Server.HTTP.Routing;
using SWS.Server.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebServer
{
    class Program
    {
        private const string _ipAddress = "127.0.0.1";
        private const int port = 8080;

        private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

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
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse(Program.HtmlForm))
                .MapPost("/HTML", new HtmlResponse("", Program.AddFormDataAction))
                .MapGet("/Content", new HtmlResponse(Program.DownloadForm))
                .MapPost("/Content", new TextFileResponse(Program.FileName))
                .MapGet("/Redirect", new RedirectResponse("https://mobile.bg"))
                .MapGet("/Cookies", new HtmlResponse("", Program.AddCookiesAction))
                .MapGet("/Session", new TextResponse("", Program.DisplaySessionAction))
                .MapGet("/Login", new HtmlResponse(Program.LoginForm))
                .MapPost("/Login", new HtmlResponse("", Program.LoginAction))
                .MapGet("/Logout", new HtmlResponse("", Program.LogOutAction));
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
