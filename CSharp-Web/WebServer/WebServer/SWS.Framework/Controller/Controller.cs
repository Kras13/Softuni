using SWS.Server.HTTP;
using SWS.Server.Responses;

namespace SWS.Framework.Controller
{
    public abstract class Controller
    {
        protected Controller(Request request)
        {
            this.Request = request;
        }

        protected Request Request { get; set; }

        protected Response Text(string text)
        {
            return new TextResponse(text);
        }

        protected Response Html(string text, CookieCollection cookies = null)
        {
            Response response = new HtmlResponse(text);

            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }

        protected Response BadRequest()
        {
            return new BadRequestResponse();
        }

        protected Response Unauthoriezed()
        {
            return new UnauthorizedResponse();
        }

        protected Response NotFound()
        {
            return new NotFoundResponse();
        }

        protected Response Redirect(string location)
        {
            return new RedirectResponse(location);
        }

        protected Response File(string fileName)
        {
            return new TextFileResponse(fileName);
        }
    }
}
