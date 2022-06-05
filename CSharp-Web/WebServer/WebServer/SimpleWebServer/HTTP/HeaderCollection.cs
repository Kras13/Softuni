using System.Collections.Generic;

namespace SimpleWebServer.Server.HTTP
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            this.headers = new Dictionary<string, Header>();
        }

        public void Add(string name, string value)
        {
            this.headers.Add(name, new Header(name, value));
        }
    }
}
