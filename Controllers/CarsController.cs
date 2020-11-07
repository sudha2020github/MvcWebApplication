using System;
using PagedList;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcWebApplication.DAL;
using MvcWebApplication.Models;


namespace MvcWebApplication.Controllers
{
    public class CarsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult SearchIndex(string searchString)
        {
            var cars = from c in db.Car
                       select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.Make.Contains(searchString));
            }
            return View(cars);

        }

        public ActionResult SearchCarType(int typeID)
        {
            IQueryable<CarType> carType = from t in db.CarType
                       select t;
            
            if (typeID > 0) {
                carType = carType.Where(t => t.CarTypeID.Equals(typeID));
            }
            var carCategory = from c in carType
                      select c.TypeName.FirstOrDefault();
            ViewBag.SelectedCategory = carCategory;
            return View(carCategory);
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.YearSortParm = sortOrder == "year" ? "year_desc" : "year";
            ViewBag.ImageSortParm = sortOrder == "image" ? "image_desc" : "image";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var cars = from s in db.Car
            select s;
            if (searchString != null) {
                page = 1;
            } else {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;           
            if (!String.IsNullOrEmpty(searchString)) {
                cars = cars.Where(s => s.Make.Contains(searchString));
            }
                       
            switch (sortOrder)
            {
                case "name_desc":
                    cars = cars.OrderByDescending(s => s.Make);
                    break;
                case "year":
                    cars = cars.OrderByDescending(s => s.Year);
                    break;
                case "year_desc":
                    cars = cars.OrderBy(s => s.Year);
                    break;
                case "image":
                    cars = cars.OrderBy(s => s.ImageFile);
                    break;
                case "image_desc":
                    cars = cars.OrderByDescending(s => s.ImageFile);
                    break;
                case "Date":
                    cars = cars.OrderBy(s => s.RecordCreationDate);
                    break;
                case "date_desc":
                    cars = cars.OrderByDescending(s => s.RecordCreationDate);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Make);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        // GET: Cars
       

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Make,Color,Year,OwnerLastName,ImageFile,RecordCreationDate,CarTypeID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Car.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Make,Color,Year,OwnerLastName,ImageFile,RecordCreationDate,CarTypeID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Car.Find(id);
            db.Car.Remove(car);
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
