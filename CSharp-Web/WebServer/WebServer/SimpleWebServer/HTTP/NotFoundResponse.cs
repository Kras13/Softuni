namespace SimpleWebServer.Server.HTTP
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }   
    }
}
