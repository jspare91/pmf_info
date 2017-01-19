using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using pmf_2.Models;
namespace pmf_2.Models
{
    public class HomeViewModel
    {
        public int SelectedProjectID { get; set; }
        public SelectList ProjectList { get; set; }
    }
}