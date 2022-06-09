namespace SimpleWebServer.Server.HTTP
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content) 
            : base(content, ContentType.Html)
        {
        }
    }
}
