using System;
using System.Text;

namespace SimpleWebServer.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;

            this.Headers.Add(Header.Server, "My Web Server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");
        }

        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public CookieCollection Cookies { get; set; }

        public string Body { get; set; }

        public Action<Request, Response> PreRenderAction { get; protected set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                sb.AppendLine(header.ToString());
            }

            foreach (Cookie cookie in this.Cookies)
            {
                sb.AppendLine($"{Header.SetCookie}: {cookie}");
            }

            sb.AppendLine();

            if (!string.IsNullOrEmpty(this.Body))
            {
                sb.Append(this.Body);
            }

            return sb.ToString();
        }
    }
}
