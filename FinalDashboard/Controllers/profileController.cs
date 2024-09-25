using FinalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
        public async Task<ActionResult> display()
        {

            return View(await db.students.ToListAsync());
        }
        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = await db.students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        // GET: students/Edit/5
        public async Task<ActionResult> editt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = await db.students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        public async Task<ActionResult> editt([Bind(Include = "id,name,gmail,password,semester,shift,dep,gender")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index","profile");
            }
            return View(student);
        }




        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.





    }
}
