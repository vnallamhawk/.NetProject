using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoachingCenter.Models;
using CoachingCenter.ViewModels;

namespace CoachingCenter.Controllers
{
    public class TeachersController : Controller
    {
        private CoachingModel db = new CoachingModel();

        // GET: Teachers
        //public ActionResult Index()
        //{
        //    return View(db.Teacheres.ToList());
        //}

        public ActionResult Index(int? id, int? TeacherID)
        {
            var viewModel = new CenterIndexData();
            viewModel.Teachers = db.Teacheres
                .Include(i => i.Students)
                .OrderBy(i => i.firstname);



            //if (id != null)
            //{
            //    ViewBag.TeacherID = id.Value;
            //    viewModel.Teachers = viewModel.Students.Where(
            //        i => i.id == id.Value).Single().;
            //}

            if (id != null)
            {
                viewModel.Teachers = db.Teacheres
                .Include(i => i.Students)
                .OrderBy(i => i.firstname);

                ViewBag.TeacherID = id.Value;
                viewModel.Students = viewModel.Teachers.Where(
                    x => x.id == id.Value).Single().Students;
            }

            return View(viewModel);
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacheres.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,skill,mobile,email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teacheres.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacheres.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,skill,mobile,email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacheres.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teacheres.Find(id);
            db.Teacheres.Remove(teacher);
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
