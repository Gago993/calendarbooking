using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarBookingProject.Models
{
    public class ApplicationSignInManager
    {

        public ApplicationUser User;
        private HttpContextBase httpContext;

        public ApplicationSignInManager(HttpContext current)
        {
            if (current != null)
            {
                this.httpContext = new HttpContextWrapper(current);
            }
        }

        public ApplicationSignInManager(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
            if(this.httpContext != null && this.httpContext.Session["User"] != null)
            {
                this.User = (ApplicationUser)httpContext.Session["User"];
            }
        }

        internal bool IsSingedIn()
        {
            if (User != null && User.UserID != 0)
            {
                return true;
            }

            return false;
        }

        internal void SingIn(User user)
        {
            ApplicationUser signInUser = new ApplicationUser()
            {
                UserID = user.ID,
            };
            this.httpContext.Session.Add("User", signInUser);
        }

        internal void SingOut()
        {
            if (this.httpContext != null && this.httpContext.Session != null)
            {
                this.httpContext.Session.Abandon();
            }
        }
    }
}