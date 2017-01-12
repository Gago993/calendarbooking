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

        public ApplicationSignInManager(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
            this.User = (ApplicationUser)httpContext.Session["User"];
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
    }
}