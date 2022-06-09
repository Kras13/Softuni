namespace SimpleWebServer.Server.HTTP
{
    public class UnauthorizedResponse : ContentResponse
    {
        public UnauthorizedResponse()
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
