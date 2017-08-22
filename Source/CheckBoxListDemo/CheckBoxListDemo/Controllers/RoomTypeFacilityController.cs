using CheckBoxListDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckBoxListDemo.Controllers
{
    public class RoomTypeFacilityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: RoomTypeFacility
        public ActionResult Index()
        {
            return View();
        }

        // GET: RoomTypeFacility/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomTypeFacility/Create
        public ActionResult Create()
        {
            List<RoomType> roomTypes = db.RoomType.ToList();
            //List<Facility> facilities = db.Facility.ToList();
            //lstCategory.Insert(0, new Category { Id = 0, Name = "--Select Category--" });

            ViewBag.RoomTypes = new SelectList(roomTypes, "Id", "Name");
            //ViewBag.Facilities = new SelectList(roomTypes, "Id", "FacilityName");

            RoomTypeFacilityVM roomTypeFacilityVM = new RoomTypeFacilityVM();
            roomTypeFacilityVM.Facilities = db.Facility.ToList();

            return View(roomTypeFacilityVM);
        }

        // POST: RoomTypeFacility/Create
        [HttpPost]
        public ActionResult Create(RoomTypeFacilityVM roomTypeFacility)
        {

            if (ModelState.IsValid)
            {
                RoomType roomType = new RoomType { Id = roomTypeFacility.RoomTypeId };
                //roomType.Id = roomTypeFacility.RoomTypeId;
                db.RoomType.Add(roomType);
                db.RoomType.Attach(roomType);

                Facility facility = new Facility { Id = roomTypeFacility.FacilityId };
                //facility.Id = roomTypeFacility.FacilityId;
                db.Facility.Add(facility);
                db.Facility.Attach(facility);

                //Add instance to the navigation property
                roomType.Facilities.Add(facility);

                db.SaveChanges();
            }

            return View(roomTypeFacility);
        }

        // GET: RoomTypeFacility/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomTypeFacility/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomTypeFacility/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomTypeFacility/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
