namespace SimpleWebServer.Server.HTTP
{
    public class BadRequestResponse : ContentResponse
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}
