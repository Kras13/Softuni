using SWS.Server.HTTP;

namespace SWS.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }   
    }
}
