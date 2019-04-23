﻿using HomeCorner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeCorner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}