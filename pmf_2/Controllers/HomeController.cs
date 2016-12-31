using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using pmf_2.Models;

namespace pmf_2.Controllers
{
    
    public class HomeController : Controller
    {
        private jrj_dbEntities db = new jrj_dbEntities();
        public ActionResult Index()
        {
            ViewBag.project_Id = new SelectList(db.projects, "project_Id", "project_name");
//ViewBag.pm_Id = new SelectList(db.proj_man, "pm_Id", "pm_name");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}