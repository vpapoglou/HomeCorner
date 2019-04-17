using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeCorner.Models;
using HomeCorner.Services;

namespace HomeCorner.Controllers
{
    public class CustomersController : Controller
    {
        private HomeCornerContext db = new HomeCornerContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = CustomerDb.GetAll();

            return View(db.Customers.ToList());
        }
    }
}