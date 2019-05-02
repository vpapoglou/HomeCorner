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
            var housesViewModel = new HousesViewModel();
            var allFeaturesList = db.Features.ToList();
            //var allRegionsList = db.Regions.ToList();
            ViewBag.AllFeatures = allFeaturesList.Select(o => new SelectListItem
            {
                Text = o.Feature.ToString(),
                Value = o.Id.ToString()
            });
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HousesViewModel housesViewModel)
        {
            
            if (ModelState.IsValid)
            {
                //var houseToAdd = db.Houses
                //.Include(i => i.Features)
                //.First();
                var houseToAdd = housesViewModel;
                //var houseToAdd = new House();

                /*if (db.Houses is null)
                {
                    houseToAdd.Availability = DateTime.Now;
                    db.Houses.Add(houseToAdd);
                }*/
                if (TryUpdateModel(houseToAdd, "house", new string[] { "Id", "Features", "RegionId" }))
                {
                    var updatedFeatures = new HashSet<byte>(housesViewModel.SelectedFeatures);
                    //var updatedRegion = housesViewModel.SelectedRegion;

                    foreach (Features features in db.Features)
                    {
                        if (!updatedFeatures.Contains(features.Id))
                        {
                            houseToAdd.House.Features.Remove(features);
                        }
                        else
                        {
                            houseToAdd.House.Features.Add((features));
                        }
                    }

                    /*foreach (Region region in db.Regions)
                    {
                        if (updatedRegion==region.RegionId)
                        {
                            houseToAdd.Region = region;
                        }
                    }*/
                }
                db.Houses.Add(houseToAdd.House);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");

            return View(housesViewModel);
        }


        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var HousesViewModel = new HousesViewModel();
            {
                HousesViewModel.House = db.Houses.Include(i => i.Features).First(i => i.Id == id);
            }

            if (HousesViewModel.House == null)
            {
                return HttpNotFound();
            }
            //var allFeaturesList = HousesViewModel.House.Features.ToList();


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
            //if (house == null)
            //{
            //    return HttpNotFound();
            //}
            //var allFeatures = db.Features.ToList();
            var housesViewModel = new HousesViewModel();
            {
                housesViewModel.House = db.Houses.Include(i => i.Features).SingleOrDefault(i => i.Id == id);
                //HousesViewModel.Features = allFeatures.ToList();
            }
            if (housesViewModel.House == null)
                return HttpNotFound();

            var allFeaturesList = db.Features.ToList();
            ViewBag.AllFeatures = allFeaturesList.Select(o => new SelectListItem
            {
                Text = o.Feature.ToString(),
                Value = o.Id.ToString()
            });

            ViewBag.RegionId =
                    new SelectList(db.Regions, "RegionId", "RegionName");

            return View(housesViewModel);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HousesViewModel housesViewModel)
        {
            if (ModelState.IsValid)
            {
                var houseToAdd = housesViewModel;
                if (TryUpdateModel(houseToAdd, "house", new string[] {"Features", "RegionId" }))
                {
                    var updatedFeatures = new HashSet<byte>(housesViewModel.SelectedFeatures);
                    //var updatedRegion = housesViewModel.SelectedRegion;

                    foreach (Features features in db.Features)
                    {
                        if (!updatedFeatures.Contains(features.Id))
                        {
                            houseToAdd.House.Features.Remove(features);
                        }
                        else
                        {
                            houseToAdd.House.Features.Add((features));
                        }
                    }
                }
                db.Entry(houseToAdd.House).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.Houses, "Id", "Title", housesViewModel.House.Id);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionName");
            return View(housesViewModel);
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