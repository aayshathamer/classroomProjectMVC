using FinalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace FinalDashboard.Controllers
{
    public class CSController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.courses = db.CS.Count();
            return View();
        }
        public async Task<ActionResult> Index3()

        {
            return View(await db.CS.ToListAsync());
        }
        private TestDBEntities2 db = new TestDBEntities2();
        // GET: CS
        public async Task<ActionResult> Index2()

        {
            return View(await db.CS.ToListAsync());
        }

        // GET: CS/Details/5

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C C = await db.CS.FindAsync(id);
            if (C == null)
            {
                return HttpNotFound();
            }
            return View(C);
        }

        // GET: CS/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: CS/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,course,duration")] C C)
        {
            if (ModelState.IsValid)
            {
                db.CS.Add(C);
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "CS");
            }

            return View(C);

        }



        // GET: CS/Edit/5

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C C = await db.CS.FindAsync(id);
            if (C == null)
            {
                return HttpNotFound();
            }
            return View(C);
        }
        // POST: CS/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,course,duration")] C C)
        {
            if (ModelState.IsValid)
            {
                db.Entry(C).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "CS");
            }
            return View(C);
        }
        // GET: CS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C C = await db.CS.FindAsync(id);
            if (C == null)
            {
                return HttpNotFound();
            }
            return View(C);
        }

        // POST: CS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            C C = await db.CS.FindAsync(id);
            db.CS.Remove(C);
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
