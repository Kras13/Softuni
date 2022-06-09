namespace SimpleWebServer.Server.HTTP
{
    public class NotFoundResponse : ContentResponse
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }   
    }
}
