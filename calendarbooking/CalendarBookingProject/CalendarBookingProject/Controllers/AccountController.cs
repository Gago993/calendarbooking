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

        public ActionResult Index()
        {
            if (UserManager.IsSingedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel LoginViewModel)
        {
            User user = db.Users.Where(u => u.Username == LoginViewModel.Username && u.Password == LoginViewModel.Password).FirstOrDefault();

            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            UserManager.SingIn(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            UserManager.SingOut();

            return RedirectToAction("Index", nameof(AccountController));
        }

        public ApplicationSignInManager UserManager{
            get
            {
                return new ApplicationSignInManager(HttpContext);
            }
        }

    }
}