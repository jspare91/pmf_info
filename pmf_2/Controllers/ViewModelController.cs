using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pmf_2.Models;
using pmf_2.Controllers;

namespace pmf_2.Controllers
{
    public class ViewModelController : Controller
    {
        // GET: ViewModel

        private jrj_dbEntities db = new jrj_dbEntities();
        public co_logDTO the_co_logDTO;
        //public ActionResult vm_Index(FormCollection collection)   //FormCollection collection
        //{
        //    if (collection.Count > 0)
        //    {
        //        String str_proj_name = collection[0];
        //        var the_cos = (from n_mb in db.co_log
        //                       join n_u in db.projects on n_mb.project_Id equals n_u.project_Id
        //                       where n_u.project_name == str_proj_name
        //                       select new co_logDTO()
        //                       {
        //                           co_Id = n_mb.co_Id,
        //                           co_num = n_mb.co_num,
        //                           gc_co = n_mb.gc_co,
        //                           description = n_mb.description,
        //                           proc = n_mb.proc,
        //                           n_proc = n_mb.n_proc,
        //                           owed = n_mb.owed,
        //                           notes = n_mb.notes
        //                       });

        //        return View(the_cos.ToList());
        //    }
        //    ////var co_logs = db.co_log.Include(p => p.);
        //    ////return View(co_logs.ToList());
        //    else
        //    {
        //        var co_log = db.co_log.Include(c => c.project);
        //        return View(co_log.ToList());
        //    }
        //}
        public class co_logDTO
        {
            public int co_Id { get; set; }
            public int project_Id { get; set; }
            public string co_num { get; set; }
            public Nullable<int> proc { get; set; }
            public Nullable<int> n_proc { get; set; }
            public string gc_co { get; set; }
            public string description { get; set; }
            public Nullable<int> owed { get; set; }
            public string notes { get; set; }

            public virtual project project { get; set; }
            // Other field you may need from the Product entity
        }
        // GET: co_log
        
    }
}
