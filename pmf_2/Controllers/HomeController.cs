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
            var model = new HomeViewModel();
            model.ProjectList = new SelectList(db.projects, "project_Id", "project_name", 1);
            model.SelectedProjectID = 0;
            return View(model);
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