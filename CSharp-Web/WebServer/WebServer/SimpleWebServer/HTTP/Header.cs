namespace SimpleWebServer.Server.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
