using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pmf_2.Models;

namespace pmf_2.Controllers
{
    public class proj_manController : Controller
    {
        private jrj_dbEntities db = new jrj_dbEntities();

        // GET: proj_man
        public ActionResult Index()
        {
            return View(db.proj_man.ToList());
        }

        // GET: proj_man/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proj_man proj_man = db.proj_man.Find(id);
            if (proj_man == null)
            {
                return HttpNotFound();
            }
            return View(proj_man);
        }

        // GET: proj_man/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proj_man/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pm_Id,pm_name")] proj_man proj_man)
        {
            if (ModelState.IsValid)
            {
                db.proj_man.Add(proj_man);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proj_man);
        }

        // GET: proj_man/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proj_man proj_man = db.proj_man.Find(id);
            if (proj_man == null)
            {
                return HttpNotFound();
            }
            return View(proj_man);
        }

        // POST: proj_man/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pm_Id,pm_name")] proj_man proj_man)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proj_man).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proj_man);
        }

        // GET: proj_man/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proj_man proj_man = db.proj_man.Find(id);
            if (proj_man == null)
            {
                return HttpNotFound();
            }
            return View(proj_man);
        }

        // POST: proj_man/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proj_man proj_man = db.proj_man.Find(id);
            db.proj_man.Remove(proj_man);
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
