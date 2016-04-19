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
    public class CentersController : Controller
    {
        private CoachingModel db = new CoachingModel();

        // GET: Centers
        //public ActionResult Index()
        //{
        //    return View(db.Centeres.ToList());
        //}

        // GET: Centers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centeres.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);


        }



        public ActionResult Index(int? id, int? TeacherID)
        {
            var viewModel = new CenterIndexData();
            viewModel.Centers = db.Centeres
                .Include(i => i.Teachers)
                .OrderBy(i => i.name);

            

            if (id != null)
            {
                ViewBag.centerId = id.Value;
                viewModel.Teachers = viewModel.Centers.Where(
                    i => i.id == id.Value).Single().Teachers;
            }

            if (TeacherID != null)
            {
                viewModel.Teachers = db.Teacheres
                .Include(i => i.Students)
                .OrderBy(i => i.firstname);

                ViewBag.TeacherID = TeacherID.Value;
                viewModel.Students = viewModel.Teachers.Where(
                    x => x.id == TeacherID.Value).Single().Students;
            }

            return View(viewModel);
        }

        public ActionResult Details_Branch(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Center center = db.Centeres.Find(id);
            List<Branch> branch = db.Branches.Where(c => c.id == id).ToList();
               // rs.Products.Where(c => c.Id == productId).FirstOrDefault();
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Centers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Centers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,type,email,mobile")] Center center)
        {
            if (ModelState.IsValid)
            {
                db.Centeres.Add(center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(center);
        }

        // GET: Centers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centeres.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // POST: Centers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,type,email,mobile")] Center center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(center);
        }

        // GET: Centers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centeres.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // POST: Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Center center = db.Centeres.Find(id);
            db.Centeres.Remove(center);
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
