using HRMCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HRMCore.Controllers
{
    public class DeptController : Controller
    {
        private HRMContext _context;

        public DeptController(HRMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Depts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dept dept)
        {
            if (ModelState.IsValid)
            {
                _context.Depts.Add(dept);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dept);
        }


        // GET: /Employee/Edit/5
        public IActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Dept dept = _context.Depts.Where(p=>p.DeptId == id).FirstOrDefault();
            //if (dept == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.DeptId = new SelectList(db.Depts, "Id", "Name", employee.DeptId);
            //ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dept dept)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(dept).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DeptId = new SelectList(db.Depts, "Id", "Name", employee.DeptId);
            //ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(dept);
        }


        public IActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Dept dept = _context.Depts.Where(p => p.DeptId==id).FirstOrDefault();
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}

            return View(dept);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dept dept = _context.Depts.Where(p => p.DeptId == id).FirstOrDefault();
            _context.Depts.Remove(dept);
            _context.SaveChanges();
            //return RedirectToAction("Create");
            return RedirectToAction("Index");
        }



    }
}
