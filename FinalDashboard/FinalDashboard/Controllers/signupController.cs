using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FinalDashboard.Models;

namespace WebApplication7.Controllers
{
    public class signupController : Controller
    {
        private TestDBEntities db = new TestDBEntities();
        // GET: signup



        public ActionResult student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Home", "Home");
            return View();
        }


        [HttpPost]
        public ActionResult student(student student)
        {
            if (db.students.Any(x => x.name == student.name))
            {
                ViewBag.Notification = "this account already exist";
                return View();
            }
            else
            {
                db.students.Add(student);
                db.SaveChanges();
                Session["id"] = student.id.ToString();
                Session["name"] = student.name.ToString();
                Session["semester"] = student.semester.ToString();
                Session["dep"] = student.dep.ToString();
                Session["shift"] = student.shift.ToString();
                ViewBag.Notification = "your account was successfully created";
                return RedirectToAction("Index");




            }
        }

    }

}