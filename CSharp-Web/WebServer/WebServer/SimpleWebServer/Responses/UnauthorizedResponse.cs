using SWS.Server.HTTP;

namespace SWS.Server.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
