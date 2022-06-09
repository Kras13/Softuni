namespace SimpleWebServer.Server.HTTP
{
    public class RedirectResponse : ContentResponse
    {
        public RedirectResponse(string location)
            : base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location, location);
        }
    }
}
