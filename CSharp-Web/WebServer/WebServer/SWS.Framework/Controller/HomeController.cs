using SWS.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
