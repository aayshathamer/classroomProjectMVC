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
    public class professorController : Controller
    {
        private TestDBEntities3 db = new TestDBEntities3();
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.courses = db.coursees.Count();
            return View();
        }
        // GET: SWE
        public async Task<ActionResult> Index2()

        {
            return View(await db.coursees.ToListAsync());
        }
        public async Task<ActionResult> Index3()

        {
            return View(await db.coursees.ToListAsync());
        }

        // GET: coursees/Details/5

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coursee coursee = await db.coursees.FindAsync(id);
            if (coursee == null)
            {
                return HttpNotFound();
            }
            return View(coursee);
        }

        // GET: coursees/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: coursees/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,course,duration")] coursee coursee)
        {
            if (ModelState.IsValid)
            {
                db.coursees.Add(coursee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "SWE");
            }

            return View(coursee);

        }



        // GET: coursees/Edit/5

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coursee coursee = await db.coursees.FindAsync(id);
            if (coursee == null)
            {
                return HttpNotFound();
            }
            return View(coursee);
        }
        // POST: coursees/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,course,duration")] coursee coursee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "SWE");
            }
            return View(coursee);
        }
        // GET: coursees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coursee coursee = await db.coursees.FindAsync(id);
            if (coursee == null)
            {
                return HttpNotFound();
            }
            return View(coursee);
        }

        // POST: coursees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            coursee coursee = await db.coursees.FindAsync(id);
            db.coursees.Remove(coursee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index2");
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
