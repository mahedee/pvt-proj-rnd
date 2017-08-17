using MVC.RdlcReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.RdlcReport.Controllers
{
    public class ReportParametersController : Controller
    {
        private ERPDBContext db = new ERPDBContext();
        // GET: ReportParameters
        public ActionResult Index()
        {
            string rptName = string.Empty;
            if (!string.IsNullOrEmpty(Request.QueryString["rptName"]))
            {
                rptName = Request.QueryString["rptName"].ToString();
            }
   
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Title");
            return View();
        }

        // GET: ReportParameters/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportParameters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportParameters/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return View();
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: ReportParameters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportParameters/Edit/5
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

        // GET: ReportParameters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportParameters/Delete/5
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
