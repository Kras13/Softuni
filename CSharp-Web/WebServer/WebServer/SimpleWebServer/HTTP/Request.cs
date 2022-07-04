using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebServer.Server.HTTP
{
    public class Request
    {
        private static Dictionary<string, Session> Sessions = new Dictionary<string, Session>();

        public Method Method { get; private set; }

        public string Url { get; set; }

        public HeaderCollection Headers { get; set; }

        public string Body { get; set; }

        public CookieCollection Cookies { get; private set; }

        public Session Session { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static Request Parse(string request)
        {
            string[] lines = request.Split("\r\n");

            string[] firstLine = lines[0].Split(' ');
            Method method = ParseMethod(firstLine[0]);
            string url = firstLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));

            CookieCollection cookies = ParseCookies(headers);

            Session session = GetSession(cookies); // if we do not have cookies for current session, new session is created
            session.LoggedTimes++;

            string[] bodyLines = lines.Skip(headers.Count + 2).ToArray(); // first header + the empty header before the body

            string body = string.Join("\r\n", bodyLines);

            Dictionary<string, string> form = ParseForm(headers, body);

            return new Request()
            {
                Method = method,
                Url = url,
                Body = body,
                Headers = headers,
                Cookies = cookies,
                Session = session,
                Form = form
            };
        }

        private static Session GetSession(CookieCollection cookies)
        {
            string sessionId = cookies.Contains(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new Session(sessionId);
            }

            return Sessions[sessionId];
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            CookieCollection cookies = new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                string cookieHeader = headers[Header.Cookie];

                string[] allCookies = cookieHeader.Split(';');

                foreach (string cookieText in allCookies)
                {
                    string[] cookieParts = cookieText.Split('=');

                    string cookieName = cookieParts[0].Trim();
                    string cookieValue = cookieParts[1].Trim();

                    cookies.Add(cookieName, cookieValue);
                }
            }

            return cookies;
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            Dictionary<string, string> formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType) &&
                headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                Dictionary<string, string> parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
        {
            Dictionary<string, string> result = HttpUtility.UrlDecode(bodyLines)
                .Split('&')
                .Select(part => part.Split('='))
                .Where(part => part.Length == 2)
                .ToDictionary(
                    part => part[0],
                    part => part[1],
                    StringComparer.InvariantCultureIgnoreCase);

            return result;
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            HeaderCollection headers = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                string[] headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                string headerName = headerParts[0];
                string headerValue = headerParts[1].Trim();

                headers.Add(headerName, headerValue);
            }

            return headers;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported!");
            }
        }
    }
}
