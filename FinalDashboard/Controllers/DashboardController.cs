using FinalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Collections;

namespace FinalDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private TestDBEntities db = new TestDBEntities();
        private string connectionString;

        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Users = db.students.Count();
            return View();
        }




    }
    }


   

   