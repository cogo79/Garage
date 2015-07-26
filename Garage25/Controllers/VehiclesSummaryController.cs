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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Garage25.Controllers
{
    public class VehiclesSummaryController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: VehiclesSummary
        //public ActionResult Index()
        //{
        //    var vehicles = db.Vehicles.Include(v => v.Owner).Include(v => v.VehicleType);
        //    return View(vehicles.ToList());
        //}
        public ActionResult GetAllVehicles()
        {
            var vehicles = from v in db.Vehicles
                   select v;

            return GetJsonContentResult(vehicles);
        }

        public ActionResult GetVehicleTypes()
        {
            var vehicleTypes = from vt in db.VehicleTypes
                               select vt;
            return GetJsonContentResult(vehicleTypes);
        }

        public ContentResult GetJsonContentResult(object data)
        {
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(data, camelCaseFormatter),
                ContentType = "application/json"
            };
            return jsonResult;
        }

        public ActionResult Index(string RegNo, int? VehicleTypeId)
        {

            var vehicles = from v in db.Vehicles
                           select v;


            if (!String.IsNullOrEmpty(RegNo))
            {
                vehicles = vehicles.Where(v => v.RegNo.Contains(RegNo));
                ViewBag.Regnummer = RegNo;
            }

            if (VehicleTypeId != null && VehicleTypeId != 0)
            {
                vehicles = vehicles.Where(v => v.VehicleTypeId == VehicleTypeId);
            }
            var vehicleTypes = from vt in db.VehicleTypes
                               select vt;
            List<VehicleType> vl = new List<VehicleType>();// = vehicleTypes.ToList();
            VehicleType vehicleType = new VehicleType();
            vehicleType.VehicleTypeId = 0;
            vehicleType.TypeDes = "All";
            vl.Add(vehicleType);

            vl.AddRange(vehicleTypes.ToList());

            SelectList list;

            list = new SelectList(vl, "VehicleTypeId", "TypeDes");

            ViewBag.VehicleTypeId = list;

            return View(vehicles);
        }


        // GET: VehiclesSummary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: VehiclesSummary/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Fname");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "TypeDes");
            return View();
        }

        // POST: VehiclesSummary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,RegNo,Brand,Color,VehicleTypeId,OwnerId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Fname", vehicle.OwnerId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "TypeDes", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: VehiclesSummary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Fname", vehicle.OwnerId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "TypeDes", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: VehiclesSummary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,RegNo,Brand,Color,VehicleTypeId,OwnerId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "Fname", vehicle.OwnerId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "TypeDes", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: VehiclesSummary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: VehiclesSummary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
