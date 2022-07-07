using SWS.Server.HTTP;

namespace SWS.Framework.Controller
{
    public class HomeController : Controller
    {
        public HomeController(Request request) 
            : base(request)
        {
        }

        public Response Index()
        {
            return Text("Hello from the server!");
        }
    }
}
