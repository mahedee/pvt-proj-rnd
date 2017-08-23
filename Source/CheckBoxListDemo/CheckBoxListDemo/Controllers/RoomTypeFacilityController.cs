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
            ViewBag.RoomTypes = new SelectList(roomTypes, "Id", "Name");
            int roomTypeId = roomTypes.FirstOrDefault().Id; //First room type id
            List<FacilityVM> facilitiesVM = GetFacilities(roomTypeId);
            return View(facilitiesVM);
        }

        private List<FacilityVM> GetFacilities(int roomTypeId)
        {
            List<FacilityVM> facilitiesVM = new List<FacilityVM>();
            List<Facility> facilitiesById = db.RoomType.Where(p => p.Id == roomTypeId).FirstOrDefault().Facilities.ToList();

            foreach (var facility in db.Facility.ToList())
            {
                if (facilitiesById.Contains(facility))
                {
                    facilitiesVM.Add(new FacilityVM { Id = facility.Id, FacilityName = facility.FacilityName, IsChecked = true });
                }
                else
                {
                    facilitiesVM.Add(new FacilityVM { Id = facility.Id, FacilityName = facility.FacilityName, IsChecked = false });
                }
            }
            return facilitiesVM;
        }

        // POST: RoomTypeFacility/Create
        [HttpPost]
        public ActionResult Create(int RoomTypes, List<FacilityVM> facilities)
        {

            if (ModelState.IsValid)
            {
                RoomType roomType = db.RoomType.Where(p => p.Id == RoomTypes).FirstOrDefault();

                foreach (Facility facility in db.Facility.ToList())
                {
                    roomType.Facilities.Remove(facility);
                }
                db.SaveChanges();

                foreach (FacilityVM faciltyVM in facilities.Where(p=>p.IsChecked == true).ToList())
                {
                    //conn.Product.Add(p);
                    // 3
                    //conn.Product.Attach(p);

                    db.RoomType.Add(roomType);
                    db.RoomType.Attach(roomType);

                    Facility facility = new Facility { Id = faciltyVM.Id };
                    db.Facility.Add(facility);
                    db.Facility.Attach(facility);
                    //Add instance to the navigation property
                    roomType.Facilities.Add(facility);
                }

                db.SaveChanges();

            }

            /*
            //RoomTypeFacilityVM roomTypeFacility;

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

            */

            return View();
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
