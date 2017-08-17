using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRMCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMCore.Controllers
{
    public class EmployeeController : Controller
    {
        private HRMContext db;

        public EmployeeController(HRMContext context)
        {
            db = context;
        }

        // GET: /Employee/
        public ActionResult Index()
        {
            List<Employee> employees = db.Employees.ToList();

            //.Include(e => e.Dept).Include(e => e.Designation);

            foreach (Employee employee in employees)
            {
                employee.Designation = db.Designations.Where(p => p.Id == employee.DesignationId).FirstOrDefault();
                employee.Dept = db.Depts.Where(p => p.DeptId == employee.DeptId).FirstOrDefault();
            }
            return View(employees);
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = db.Employees.Where(p => p.Id == id).FirstOrDefault();
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}
            return View(employee);
        }


        // GET: /Employee/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Depts, "DeptId", "Name");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name");

            List<Dept> lstDept = db.Depts.ToList();
            ViewBag.DeptList = lstDept;

            List<Designation> lstDesignation = db.Designations.ToList();
            ViewBag.DesignationList = lstDesignation;

            return View();
        }



        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ActionDate = DateTime.Now;
                if (employee.Id != 0)
                    db.Entry(employee).State = EntityState.Modified;
                else
                    db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Depts, "DeptId", "Name", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(employee);
        }




        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = db.Employees.Where(p => p.Id == id).FirstOrDefault();

            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}

            ViewBag.DeptId = new SelectList(db.Depts, "DeptId", "Name", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Depts, "DeptId", "Name", employee.DeptId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = db.Employees.Where(p => p.Id == id).FirstOrDefault();
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}

            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Where(p => p.Id == id).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
           // return RedirectToAction("Create");
            return RedirectToAction("Index");
        }




        public ActionResult _LoadSearchEmployee(string desigId, string deptId)
        {
            List<Employee> employee = new List<Employee>();
            int _desigId = 0;
            int _deptId = 0;
            Int32.TryParse(desigId, out _desigId);
            Int32.TryParse(deptId, out _deptId);

            employee = db.Employees.Where(p => (p.DeptId == _deptId || _deptId == 0) &&
             (p.DesignationId == _desigId || _desigId == 0)).ToList();
            return PartialView(employee);
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
