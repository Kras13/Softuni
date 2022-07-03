using SimpleWebServer.Server.Common;
using System.Collections.Generic;

namespace SimpleWebServer.Server.HTTP
{
    public class Session
    {
        public const string SessionCookieName = "MyWebServerSID";

        public const string SessionCurrentDateKey = "CurrentDate";

        private Dictionary<string, string> data;

        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            this.Id = id;

            this.data = new Dictionary<string, string>();
        }

        public string Id { get; set; }

        public string this[string key]
        {
            get
            {
                return this.data[key];
            }

            set
            {
                this.data[key] = value;
            }
        }

        public bool Contains(string key)
        {
            return this.data.ContainsKey(key);
        }
    }
}
