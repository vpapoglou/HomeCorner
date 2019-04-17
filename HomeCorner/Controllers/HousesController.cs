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
        private HomeCornerContext db = new HomeCornerContext();

        // GET: Houses
        public ActionResult Index()
        {

            return View(db.Houses.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(house);
        }
    }
}