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
            var allFeaturesList = db.Features.ToList();
            var HousesViewModel = new HousesViewModel();

            ViewBag.AllFeatures = allFeaturesList.Select(o => new SelectListItem
            {
                Text = o.Feature.ToString(),
                Value = o.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HousesViewModel housesViewModel)
        {

            if (ModelState.IsValid)
            {
                var houseToAdd = db.Houses
                .Include(i => i.Features)
                .First();

                if (TryUpdateModel(houseToAdd, "house", new string[] { "Id", "Feature" }))
                {
                    var updatedFeatures = new HashSet<byte>(housesViewModel.SelectedFeatures);

                    foreach (Features features in db.Features)
                    {
                        if (!updatedFeatures.Contains(features.Id))
                        {
                            houseToAdd.Features.Remove(features);
                        }
                        else
                        {
                            houseToAdd.Features.Add((features));
                        }
                    }
                }
                db.Houses.Add(houseToAdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(housesViewModel);
        }


        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //House house = db.Houses.Find(id);
            
            var HousesViewModel = new HousesViewModel();
            {
                HousesViewModel.House = db.Houses.Include(i => i.Features).First(i => i.Id == id);
                //HousesViewModel.Features = allFeatures.ToList();
            }
            if (HousesViewModel.House == null)
            {
                return HttpNotFound();
            }
            var allFeaturesList = HousesViewModel.House.Features.ToList();

            return View(HousesViewModel);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //House house = db.Houses.Find(id);
            //var allFeatures = db.Features.ToList();
            var HousesViewModel = new HousesViewModel();
            {
                HousesViewModel.House = db.Houses.Include(i => i.Features).First(i => i.Id == id);
                //HousesViewModel.Features = allFeatures.ToList();
            }
            if (HousesViewModel.House == null)
                return HttpNotFound();

            var allFeaturesList = db.Features.ToList();
            HousesViewModel.AllFeatures = allFeaturesList.Select(o => new SelectListItem
            {
                Text = o.Feature,
                Value = o.Id.ToString()
            });

            //ViewBag.CustomerID =
            //        new SelectList(db.Customers, "Id", "Name", HousesViewModel.House.Id);

            return View(HousesViewModel);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HousesViewModel housesViewModel)
        {
            var houseToEdit = db.Houses
                .Include(i => i.Features)
                .First();

            if (TryUpdateModel(houseToEdit, "house", new string[] { "Id", "Feature" }))
            {
                var updatedFeatures = new HashSet<byte>(housesViewModel.SelectedFeatures);

                foreach (Features features in db.Features)
                {
                    if (!updatedFeatures.Contains(features.Id))
                    {
                        houseToEdit.Features.Remove(features);
                    }
                    else
                    {
                        houseToEdit.Features.Add((features));
                    }
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(houseToEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Houses, "Id", "Title", houseToEdit);
            return View();
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