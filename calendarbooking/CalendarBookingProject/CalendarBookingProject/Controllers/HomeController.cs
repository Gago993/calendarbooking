﻿using CalendarBookingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalendarBookingProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!UserManager.IsSingedIn())
            {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ApplicationSignInManager UserManager
        {
            get
            {
                return new ApplicationSignInManager(HttpContext);
            }
        }

    }
}