using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeCorner.Models;
using HomeCorner.Services;

namespace HomeCorner.Controllers
{
    public class HousesController : Controller
    {
        // GET: Houses
        public ActionResult Index()
        {
            var houses = HouseDb.GetAll();

            return View(houses);
        }
    }
}