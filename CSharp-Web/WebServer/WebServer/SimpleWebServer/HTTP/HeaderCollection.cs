using System.Collections;
using System.Collections.Generic;

namespace SWS.Server.HTTP
{
    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            this.headers = new Dictionary<string, Header>();
        }

        public int Count
        {
            get
            {
                return this.headers.Count;
            }
        }

        public string this[string name]
        {
            get
            {
                return this.headers[name].Value;
            }
        }

        public bool Contains(string name)
        {
            return this.headers.ContainsKey(name);
        }

        public void Add(string name, string value)
        {
            headers[name] = new Header(name, value);
            //this.headers.Add(name, new Header(name, value));
        }

        public IEnumerator<Header> GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
