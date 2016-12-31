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
    public class co_logController : Controller
    {
        private jrj_dbEntities db = new jrj_dbEntities();

        // GET: co_log
        public ActionResult Index()   //FormCollection collection
        {
            //if (collection.Count > 0)
            //{
            //    String str_proj_name = collection[0];
            //    var the_cos = (from n_mb in db.co_log
            //                   join n_u in db.projects on n_mb.project_Id equals n_u.project_Id
            //                   where n_u.project_name == str_proj_name
            //                    select new co_log()
            //                    {
            //                        co_Id = n_mb.co_Id,
            //                        co_num = n_mb.co_num,
            //                        gc_co = n_mb.gc_co,
            //                        description = n_mb.description,
            //                        proc = n_mb.proc,
            //                        n_proc = n_mb.n_proc,
            //                        owed=n_mb.owed,
            //                        notes=n_mb.notes
            //                    });
            
            //return View(the_cos.ToList());
            //}
            ////var co_logs = db.co_log.Include(p => p.);
            ////return View(co_logs.ToList());
            return View();
                                                        //co_log.ToList()
        }

        // GET: co_log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            co_log co_log = db.co_log.Find(id);
            if (co_log == null)
            {
                return HttpNotFound();
            }
            return View(co_log);
        }

        // GET: co_log/Create
        public ActionResult Create()
        {
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name");
            return View();
        }

        // POST: co_log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "co_Id,project_Id,co_num,proc,n_proc,gc_co,description,owed,notes")] co_log co_log)
        {
            if (ModelState.IsValid)
            {
                db.co_log.Add(co_log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name", co_log.project_Id);
            return View(co_log);
        }

        // GET: co_log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            co_log co_log = db.co_log.Find(id);
            if (co_log == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name", co_log.project_Id);
            return View(co_log);
        }

        // POST: co_log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "co_Id,project_Id,co_num,proc,n_proc,gc_co,description,owed,notes")] co_log co_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(co_log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name", co_log.project_Id);
            return View(co_log);
        }

        // GET: co_log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            co_log co_log = db.co_log.Find(id);
            if (co_log == null)
            {
                return HttpNotFound();
            }
            return View(co_log);
        }

        // POST: co_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            co_log co_log = db.co_log.Find(id);
            db.co_log.Remove(co_log);
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
