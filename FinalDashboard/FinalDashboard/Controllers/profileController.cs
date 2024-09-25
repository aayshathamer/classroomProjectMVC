using FinalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace FinalDashboard.Controllers
{
    public class profileController : Controller
    {
        private TestDBEntities db = new TestDBEntities();


        // GET: login

        [HttpPost]
        public ActionResult Index(student student)
        {
            // Retrieve user information from the session

            Session["id"] = student.id.ToString();
            Session["name"] = student.name.ToString();
            Session["semester"] = student.semester.ToString();
            Session["dep"] = student.dep.ToString();
            Session["shift"] = student.shift.ToString();

            // Retrieve additional user data from the database based on the user ID


            // Pass the user data to the view or do any other necessary processing
            return View();
        }

        public ActionResult Index()
        {

            return View();
        }




        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.





    }
}
