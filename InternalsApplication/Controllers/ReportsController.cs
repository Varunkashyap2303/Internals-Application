using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternalsApplication.Models;

namespace InternalsApplication.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reports
        public ActionResult Index()
        {
            var reports = db.Reports.Include(r => r.Department).Include(r => r.Script).Include(r => r.Student).Include(r => r.Subject).Include(r => r.Teacher);
            return View(reports.ToList());
        }

        // GET: Reports/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name");
            ViewBag.Script_ID = new SelectList(db.Scripts, "Script_ID", "Teacher_ID");
            ViewBag.USN = new SelectList(db.Students, "USN", "Name");
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name");
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name");

            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Report_ID,Total,Percentage,USN,Teacher_ID,Dept_No,Subject_Code,Script_ID")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name", report.Dept_No);
            ViewBag.Script_ID = new SelectList(db.Scripts, "Script_ID", "Teacher_ID", report.Script_ID);
            ViewBag.USN = new SelectList(db.Students, "USN", "Name", report.USN);
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name", report.Subject_Code);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", report.Teacher_ID);
            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name", report.Dept_No);
            ViewBag.Script_ID = new SelectList(db.Scripts, "Script_ID", "Teacher_ID", report.Script_ID);
            ViewBag.USN = new SelectList(db.Students, "USN", "Name", report.USN);
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name", report.Subject_Code);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", report.Teacher_ID);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Report_ID,Total,Percentage,USN,Teacher_ID,Dept_No,Subject_Code,Script_ID")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name", report.Dept_No);
            ViewBag.Script_ID = new SelectList(db.Scripts, "Script_ID", "Teacher_ID", report.Script_ID);
            ViewBag.USN = new SelectList(db.Students, "USN", "Name", report.USN);
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name", report.Subject_Code);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", report.Teacher_ID);
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Report report = db.Reports.Find(id);
            db.Reports.Remove(report);
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
