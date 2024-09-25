using FinalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FinalDashboard.Controllers
{
    public class stuRegController : Controller
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: students
        public async Task<ActionResult> Index()
        {
            return View(await db.students.ToListAsync());
        }

        // GET: students/Details/5

        public async Task<ActionResult> Details(int? id)
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

        // GET: students/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: students/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,gmail,password,semester,shift,dep,gender")] student student)
        {
            if (db.students.Any(x => x.gmail == student.gmail))
            {
                ViewBag.Notification = "name or gmail already exist";
                return View();
            }
            else
            {
                db.students.Add(student);
                db.SaveChanges();
                Session["id"] = student.id.ToString();
                Session["name"] = student.name.ToString();
                Session["gmail"] = student.gmail.ToString();
                Session["semester"] = student.semester.ToString();
                Session["dep"] = student.dep.ToString();
                Session["shift"] = student.shift.ToString();
                ViewBag.Notification = "your account was successfully created";

                return RedirectToAction("Index", "Home");



            

           
            }
           

            return View(student);

        }


        // GET: students/Edit/5

        public async Task<ActionResult> Edit(int? id)
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
        // POST: students/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,gmail,password,semester,shift,dep,gender")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Reg");
            }
            return View(student);
        }
        // GET: students/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            student student = await db.students.FindAsync(id);
            db.students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
