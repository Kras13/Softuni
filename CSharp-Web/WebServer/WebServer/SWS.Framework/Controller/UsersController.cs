using SWS.Server.HTTP;
using System;

namespace SWS.Framework.Controller
{
    public class UsersController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";

        private const string Username = "user";

        private const string Password = "user123";

        public UsersController(Request request)
            : base(request)
        {
        }

        public Response Login()
        {
            return base.Html(LoginForm);
        }

        public Response LoginUser()
        {
            this.Request.Session.Clear();

            bool credentialsMatch =
                this.Request.Form["Username"] == UsersController.Username &&
                this.Request.Form["Password"] == UsersController.Password;

            if (credentialsMatch)
            {
                if (!Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";

                    CookieCollection cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, this.Request.Session.Id);

                    return base.Html("<h3>Logged successfully!</h3>", cookies);
                }

                return base.Html("<h3>Logged successfully</h3>");
            }

            return base.Redirect("/Login");
        }
    }
}
