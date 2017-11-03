using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage25.DataAccessLayer;
using Garage25.Models;

namespace Garage25.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            var parkedVehicls = db.ParkedVehicls.Include(p => p.Color).Include(p => p.Person).Include(p => p.VehicleType);
            return View(parkedVehicls.ToList());
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicls.Find(id);                     
           
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name");
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "MailAddress");
            ViewBag.VehicleTypeId = new SelectList(db.VechicleTypes, "Id", "TypeName");
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationNumber,VehicleBrand,InDate,ParkingSpot,VehicleTypeId,PersonId,ColorId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.ParkedVehicls.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", parkedVehicle.ColorId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "MailAddress", parkedVehicle.PersonId);
            ViewBag.VehicleTypeId = new SelectList(db.VechicleTypes, "Id", "TypeName", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicls.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", parkedVehicle.ColorId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "MailAddress", parkedVehicle.PersonId);
            ViewBag.VehicleTypeId = new SelectList(db.VechicleTypes, "Id", "TypeName", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationNumber,VehicleBrand,InDate,ParkingSpot,VehicleTypeId,PersonId,ColorId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", parkedVehicle.ColorId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "MailAddress", parkedVehicle.PersonId);
            ViewBag.VehicleTypeId = new SelectList(db.VechicleTypes, "Id", "TypeName", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicls.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicls.Find(id);
            db.ParkedVehicls.Remove(parkedVehicle);
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
