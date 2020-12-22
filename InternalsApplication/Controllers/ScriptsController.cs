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
    public class ScriptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scripts
        [Route("Scripts")]
        [Route("Scripts/Index")]
        public ActionResult Index()
        {
            var scripts = db.Scripts.Include(s => s.Subject).Include(s => s.Teacher);
            return View(scripts.ToList());
        }

        // GET: Scripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // GET: Scripts/Create
        public ActionResult Create()
        {
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name");
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name");
            ViewBag.USN = new SelectList(db.Students, "USN", "USN");
            return View();
        }

        // POST: Scripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Script_ID,IA1,IA2,IA3,Teacher_ID,Subject_Code,USN")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Scripts.Add(script);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name", script.Subject_Code);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", script.Teacher_ID);
            ViewBag.USN = new SelectList(db.Students, "USN", "USN",script.USN);
            return View(script);
        }

        // GET: Scripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name", script.Subject_Code);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", script.Teacher_ID);
            ViewBag.USN = new SelectList(db.Students, "USN", "USN",script.USN);
            return View(script);
        }

        // POST: Scripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Script_ID,IA1,IA2,IA3,Teacher_ID,Subject_Code,USN")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Entry(script).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "Subject_Name", script.Subject_Code);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", script.Teacher_ID);
            ViewBag.USN = new SelectList(db.Students, "USN", "USN",script.USN);
            return View(script);
        }

        // GET: Scripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // POST: Scripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Script script = db.Scripts.Find(id);
            db.Scripts.Remove(script);
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
