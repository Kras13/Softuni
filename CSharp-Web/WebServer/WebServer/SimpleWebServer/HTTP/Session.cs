using SWS.Server.Common;
using System.Collections.Generic;

namespace SWS.Server.HTTP
{
    public class Session
    {
        public const string SessionCookieName = "MyWebServerSID";

        public const string SessionCurrentDateKey = "CurrentDate";

        public const string SessionUserKey = "AuthenticatedUserId";

        private Dictionary<string, string> data;

        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            this.Id = id;

            this.data = new Dictionary<string, string>();
        }

        public string Id { get; set; }

        public int LoggedTimes { get; set; } = 0;

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

        public bool ContainsKey(string key)
        {
            return this.data.ContainsKey(key);
        }

        public void Clear()
        {
            this.data.Clear();
        }
    }
}
