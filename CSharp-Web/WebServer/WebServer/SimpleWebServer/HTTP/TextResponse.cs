namespace SimpleWebServer.Server.HTTP
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content) 
            : base(content, ContentType.PlainText)
        {
        }
    }
}
