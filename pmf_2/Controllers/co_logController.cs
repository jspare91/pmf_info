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
        
        public ActionResult Index( FormCollection collection, int? the_int_Id)  
        {
            if (collection.Count != 0)
            {
                var the_cos = from n_mb in db.co_log select n_mb;
                
                var int_Id = Convert.ToInt32(collection[0]);
                var the_proj = from n_u in db.projects select n_u;
                the_proj= the_proj.Where(n_u =>n_u.project_Id.Equals (int_Id));
                the_cos = the_cos.Where(n_mb => n_mb.project_Id.Equals(int_Id));
                //the_cos.Include(c => c.project);
                ViewBag.project_Id = int_Id;
                var the_proj_name = the_proj.ToArray();
                string t_p_n = the_proj_name[0].project_name.ToString();
                ViewBag.project_name = t_p_n;
                return View(the_cos.ToList());
            }
            else
            {
                if (the_int_Id!=null)
                {
                    var the_cos = from n_mb in db.co_log select n_mb;
                    int int_Id = Convert.ToInt32(the_int_Id);
                    var the_proj = from n_u in db.projects select n_u;
                    the_proj = the_proj.Where(n_u => n_u.project_Id.Equals(int_Id));
                    the_cos = the_cos.Where(n_mb => n_mb.project_Id.Equals(int_Id));
                    //the_cos.Include(c => c.project);
                    ViewBag.project_Id = int_Id;
                    var the_proj_name = the_proj.ToArray();
                    string t_p_n = the_proj_name[0].project_name.ToString();
                    ViewBag.project_name = t_p_n;
                    return View(the_cos.ToList());
                }
                else
                {
                    var co_log = db.co_log;
                    return View(co_log.ToList());
                }
            }
        }
        
        // GET: co_log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            co_log co_log = db.co_log.Find(id);
            ViewBag.the_proj_Id = co_log.project_Id;
            if (co_log == null)
            {
                return HttpNotFound();
            }

            return View(co_log);
        }

        // GET: co_log/Create
        public ActionResult Create(int? proj_ID)
        {
            ViewBag.project_Id = proj_ID;
            if (proj_ID != null)
            { 
                ViewBag.the_proj_Id = proj_ID;
            }
            //ViewBag.the_proj_Id = co_log.project_Id;
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
                return RedirectToAction("Index", new { the_int_Id = co_log.project_Id });
               // return RedirectToAction("Index");
            }

            //ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name", co_log.project_Id);
            var co_log_a = db.co_log.Include(c => c.project);
            return View(co_log_a.ToList());
            //return View(co_log);
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
            ViewBag.the_proj_Id = co_log.project_Id;
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
                return RedirectToAction("Index", new { the_int_Id = co_log.project_Id });
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
            
            ViewBag.the_proj_Id = co_log.project_Id;
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
            return RedirectToAction("Index", new { the_int_Id = co_log.project_Id });
            //return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private class project_list
        {
        }
    }
}
