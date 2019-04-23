using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeCorner.Models;
using HomeCorner.ViewModels;
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
            //ViewBag.Id = new SelectList(db.Houses, "Id", "Region", "Address", "Price", "OwnerId", "Title", "Description", "PostalCode", "Occupancy", "Availability");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Region, Address, Price, OwnerId, Title, Description, PostalCode, Occupancy, Availability")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            var features = house.Features;

            if (house == null)
            {
                return HttpNotFound();
            }
            
            var FeaturesDetailsViewModel = new FeaturesDetailsViewModel();
            {
                FeaturesDetailsViewModel.House = house;
                FeaturesDetailsViewModel.Features = features.ToList();
            }

            
            //viewModel.ActionMovies = movies.Where(m => m.Genre.Name == "Action").ToList();
            //viewModel.ThrillerMovies = movies.Where(m => m.Genre.Name == "Thriller").ToList();
            

            return View(FeaturesDetailsViewModel);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id = new SelectList(db.Houses, "Id", "Region", "Address", "Price", "OwnerId", "Title", "Description", "PostalCode", "Occupancy", "Availability", house.Id);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Region, Address, Price, OwnerId, Title, Description, PostalCode, Occupancy, Availability")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Houses, "Id", "Title", house.Id);
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}