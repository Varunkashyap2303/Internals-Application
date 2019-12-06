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
    public class ClassRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassRooms
        public ActionResult Index()
        {
            var classRooms = db.ClassRooms.Include(c => c.Department).Include(c => c.Teacher);
            return View(classRooms.ToList());
        }

        // GET: ClassRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = db.ClassRooms.Find(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            return View(classRoom);
        }

        // GET: ClassRooms/Create
        public ActionResult Create()
        {
            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name");
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name");
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Room_No,Duration,Dept_No,Teacher_ID,USN")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                db.ClassRooms.Add(classRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name", classRoom.Dept_No);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", classRoom.Teacher_ID);
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = db.ClassRooms.Find(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name", classRoom.Dept_No);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", classRoom.Teacher_ID);
            return View(classRoom);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Room_No,Duration,Dept_No,Teacher_ID,USN")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept_No = new SelectList(db.Departments, "Dept_No", "Dept_Name", classRoom.Dept_No);
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "Teacher_ID", "Teacher_Name", classRoom.Teacher_ID);
            return View(classRoom);
        }

        // GET: ClassRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoom classRoom = db.ClassRooms.Find(id);
            if (classRoom == null)
            {
                return HttpNotFound();
            }
            return View(classRoom);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassRoom classRoom = db.ClassRooms.Find(id);
            db.ClassRooms.Remove(classRoom);
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
