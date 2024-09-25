using FinalDashboard.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDashboard.Controllers
{
    public class loginController : Controller
    {
        private TestDBEntities db = new TestDBEntities();
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(student student)
        {



            if (student.gmail == "admin@gmail.com" && student.password == "123")
            {

                // Retrieve user information from the session




                // Retrieve user information from the session


                return RedirectToAction("Index", "Dashboard");




            }

            if (db.students.Any(x => x.gmail == student.gmail) && db.students.Any(x => x.password == student.password))
            {

                // Retrieve user information from the session


                return RedirectToAction("display", "profile");
            }
            else
            {
                ViewBag.Notification = "error";



            }




            return View();

        }
    }
}
