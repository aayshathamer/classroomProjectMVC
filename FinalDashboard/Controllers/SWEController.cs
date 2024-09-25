using FinalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace FinalDashboard.Controllers
{
    public class SWEController : Controller
    {
        private TestDBEntities3 db = new TestDBEntities3();
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.courses = db.softwarees.Count();
            return View();
        }
        public async Task<ActionResult> Index3()

        {
            return View(await db.softwarees.ToListAsync());
        }
        // GET: SWE
        public async Task<ActionResult> Index2()

        {
            return View(await db.softwarees.ToListAsync());
        }

        // GET: softwarees/Details/5

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            softwaree softwaree = await db.softwarees.FindAsync(id);
            if (softwaree == null)
            {
                return HttpNotFound();
            }
            return View(softwaree);
        }

        // GET: softwarees/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: softwarees/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,course,duration")] softwaree softwaree)
        {
            if (ModelState.IsValid)
            {
                db.softwarees.Add(softwaree);
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "SWE");
            }

            return View(softwaree);

        }



        // GET: softwarees/Edit/5

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            softwaree softwaree = await db.softwarees.FindAsync(id);
            if (softwaree == null)
            {
                return HttpNotFound();
            }
            return View(softwaree);
        }
        // POST: softwarees/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,course,duration")] softwaree softwaree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softwaree).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "SWE");
            }
            return View(softwaree);
        }
        // GET: softwarees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            softwaree softwaree = await db.softwarees.FindAsync(id);
            if (softwaree == null)
            {
                return HttpNotFound();
            }
            return View(softwaree);
        }

        // POST: softwarees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            softwaree softwaree = await db.softwarees.FindAsync(id);
            db.softwarees.Remove(softwaree);
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
