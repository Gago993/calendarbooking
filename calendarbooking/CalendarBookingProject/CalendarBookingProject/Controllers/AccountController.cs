using CalendarBookingProject.Models;
using CalendarBookingProject.ProjectContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarBookingProject.Controllers
{
    public class AccountController : Controller
    {
        private CalendarBookingDbContext db = new CalendarBookingDbContext();
        private ApplicationSignInManager UserManager;


        public AccountController()
        {
            UserManager = new ApplicationSignInManager(HttpContext);
        }

        public ActionResult Login(LoginModel LoginViewModel)
        {
            if(UserManager.IsSingedIn())
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
            }

            User user = db.Users.Where(u => u.Username == LoginViewModel.Username && u.Password == LoginViewModel.Password).FirstOrDefault();

            if(user == null)
            {
                return new HttpNotFoundResult();
            }

            UserManager.SingIn(user);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

    }
}