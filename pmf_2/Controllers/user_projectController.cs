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
    public class user_projectController : Controller
    {
        private jrj_dbEntities db = new jrj_dbEntities();

        // GET: user_project
        public ActionResult Index()
        {
            var user_project = db.user_project.Include(u => u.AspNetUser).Include(u => u.project);
            return View(user_project.ToList());
        }

        // GET: user_project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_project user_project = db.user_project.Find(id);
            if (user_project == null)
            {
                return HttpNotFound();
            }
            return View(user_project);
        }

        // GET: user_project/Create
        public ActionResult Create()
        {
            ViewBag.user_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name");
            return View();
        }

        // POST: user_project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_proj_Id,user_Id,project_Id")] user_project user_project)
        {
            if (ModelState.IsValid)
            {
                db.user_project.Add(user_project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_Id = new SelectList(db.AspNetUsers, "Id", "Email", user_project.user_Id);
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name", user_project.project_Id);
            return View(user_project);
        }

        // GET: user_project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_project user_project = db.user_project.Find(id);
            if (user_project == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_Id = new SelectList(db.AspNetUsers, "Id", "Email", user_project.user_Id);
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name", user_project.project_Id);
            return View(user_project);
        }

        // POST: user_project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_proj_Id,user_Id,project_Id")] user_project user_project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_Id = new SelectList(db.AspNetUsers, "Id", "Email", user_project.user_Id);
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name", user_project.project_Id);
            return View(user_project);
        }

        // GET: user_project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_project user_project = db.user_project.Find(id);
            if (user_project == null)
            {
                return HttpNotFound();
            }
            return View(user_project);
        }

        // POST: user_project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_project user_project = db.user_project.Find(id);
            db.user_project.Remove(user_project);
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
