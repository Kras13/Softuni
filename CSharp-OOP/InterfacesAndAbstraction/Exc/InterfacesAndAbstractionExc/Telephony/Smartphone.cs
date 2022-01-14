namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            Validator.CallingValidating(number, "Invalid number!");

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            Validator.BrowsingValidator(url, "Invalid URL!");

            return $"Browsing: {url}!";
        }
    }
}
