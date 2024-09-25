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
    public class ICTController : Controller
    {
        private TestDBEntities3 db = new TestDBEntities3();
        // GET: ICT
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.courses = db.ictts.Count();
            return View();
        }
        public async Task<ActionResult> Index3()

        {
            return View(await db.ictts.ToListAsync());
        }
        // GET: SWE
        public async Task<ActionResult> Index2()

        {
            return View(await db.ictts.ToListAsync());
        }

        // GET: ictts/Details/5

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ictt ictt = await db.ictts.FindAsync(id);
            if (ictt == null)
            {
                return HttpNotFound();
            }
            return View(ictt);
        }

        // GET: ictts/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: ictts/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,course,duration")] ictt ictt)
        {
            if (ModelState.IsValid)
            {
                db.ictts.Add(ictt);
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "SWE");
            }

            return View(ictt);

        }



        // GET: ictts/Edit/5

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ictt ictt = await db.ictts.FindAsync(id);
            if (ictt == null)
            {
                return HttpNotFound();
            }
            return View(ictt);
        }
        // POST: ictts/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,course,duration")] ictt ictt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ictt).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "SWE");
            }
            return View(ictt);
        }
        // GET: ictts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ictt ictt = await db.ictts.FindAsync(id);
            if (ictt == null)
            {
                return HttpNotFound();
            }
            return View(ictt);
        }

        // POST: ictts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ictt ictt = await db.ictts.FindAsync(id);
            db.ictts.Remove(ictt);
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
    