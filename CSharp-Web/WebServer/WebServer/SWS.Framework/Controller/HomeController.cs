using SWS.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SWS.Framework.Controller
{
    public class HomeController : Controller
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

        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index()
        {
            return Text("Hello from the server!");
        }

        public Response Redirect()
        {
            return Redirect("https://mobile.bg");
        }

        public Response Html()
        {
            return Html(HomeController.HtmlForm);
        }

        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content()
        {
            return Html(HomeController.DownloadForm);
        }

        public Response Cookies()
        {
            if (this.Request.Cookies.Any(
                c => c.Name != SWS.Server.HTTP.Session.SessionCookieName))
            {
                var responseBuilder = new StringBuilder();
                responseBuilder.AppendLine("<h1>Cookies</h1>");

                responseBuilder
                    .Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in this.Request.Cookies)
                {
                    responseBuilder.Append("<tr>");

                    responseBuilder
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    responseBuilder
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");

                    responseBuilder.Append("</tr>");
                }

                responseBuilder.Append("/table");

                return base.Html(responseBuilder.ToString());
            }

            // if there are not cookies brought in the request then we should add them to request

            CookieCollection cookies = new CookieCollection();

            cookies.Add("My-Cookie", "My-Cookie-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Cookie-Value");

            return base.Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            string currentDateKey = "CurrentDate";
            bool sessionExists = this.Request.Session.ContainsKey(currentDateKey);

            if (sessionExists)
            {
                string currentDate = this.Request.Session[currentDateKey];

                return base.Text($"Stored date: {currentDate}!");
            }

            return base.Text("Current date stored!");
        }

        public Response DownloadContent()
        {
            DownloadSiteAsTextFile(
                HomeController.FileName,
                    new string[] { "https://judge.softuni.org", "https://softuni.org" })
            .Wait();

            return File(HomeController.FileName);
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

            await System.IO.File.WriteAllTextAsync(fileName, responsesString);
        }
    }
}
