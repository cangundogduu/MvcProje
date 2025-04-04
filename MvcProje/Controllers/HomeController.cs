﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkımda Alanı.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Bilgi()
        {
            return View();
        }

        public ActionResult Profil()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}