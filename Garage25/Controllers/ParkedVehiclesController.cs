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
using Garage25.Models.ViewModels;

namespace Garage25.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();
        private int MinuteCost = 1;


        // GET: SummaryParkedVehicles

        public ActionResult Index()
        {

            var parkedVehicles = db.ParkedVehicls.Include(p => p.Person).Include(p => p.VehicleType);

            //var parkedSummary = parkedVehicles.Select(v => new SummaryParkedVehicles
            //{
            //    Owner = v.Person.FirstName + " " + v.Person.LastName,
            //    VehicleTypeName = v.VehicleType.TypeName,
            //    RegistrationNumber = v.RegistrationNumber,
            //    ParkedTime = (DateTime.Now.Subtract(v.InDate))
            //});

            var parkedSummaryList = new List<SummaryParkedVehicles>();

            foreach (var parkedSummary in parkedVehicles)
            {
                SummaryParkedVehicles SummaryParked = new SummaryParkedVehicles();
                SummaryParked.Id = parkedSummary.Id;
                SummaryParked.Owner = parkedSummary.Person.FirstName + " " + parkedSummary.Person.LastName;
                SummaryParked.VehicleTypeName = parkedSummary.VehicleType.TypeName;
                SummaryParked.RegistrationNumber = parkedSummary.RegistrationNumber;
               // SummaryParked.ParkedTime = (DateTime.Now.Subtract(parkedSummary.InDate));
                SummaryParked.Days = (DateTime.Now.Subtract(parkedSummary.InDate).Days);
                SummaryParked.Hours = (DateTime.Now.Subtract(parkedSummary.InDate).Hours);
                SummaryParked.Minutes = (DateTime.Now.Subtract(parkedSummary.InDate).Minutes);

                parkedSummaryList.Add(SummaryParked);
            }

            return View(parkedSummaryList);

          


        }

        

        // GET: ParkedVehicles
        public ActionResult DetailedIndex()
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
        public ActionResult Create([Bind(Include = "Id,RegistrationNumber,VehicleBrand,ParkingSpot,VehicleTypeId,PersonId,ColorId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                parkedVehicle.InDate = DateTime.Now;
                db.ParkedVehicls.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //parkedVehicle.InDate = DateTime.Now;
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

        public ActionResult CheckOut(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ParkedVehicle parkedVehicle = db.ParkedVehicls.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }

            var RecieptVehicle = parkedVehicle;
            Receipt recVehicle = new Receipt();
            recVehicle.Id = RecieptVehicle.Id;
            recVehicle.Owner = RecieptVehicle.Person.FirstName + " " + RecieptVehicle.Person.LastName;
            recVehicle.RegistrationNumber = RecieptVehicle.RegistrationNumber;
            recVehicle.CheckInDate = RecieptVehicle.InDate;
            recVehicle.CheckOutDate = DateTime.Now;
            recVehicle.CostPerMinute = MinuteCost;

            recVehicle.Days = (DateTime.Now.Subtract(RecieptVehicle.InDate).Days);
            recVehicle.Hours = (DateTime.Now.Subtract(RecieptVehicle.InDate).Hours);
            recVehicle.Minutes = (DateTime.Now.Subtract(RecieptVehicle.InDate).Minutes);


            recVehicle.TotalParkedTime = (int)DateTime.Now.Subtract(RecieptVehicle.InDate).TotalMinutes+1;
            recVehicle.TotalCost = recVehicle.TotalParkedTime * MinuteCost;

            return View(recVehicle);
        }


        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("CheckOut")]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOutConfirmed(int id)
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
