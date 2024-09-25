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
    public class libraryController : Controller
    {
        private TestDBEntities4 db = new TestDBEntities4();
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Books = db.BLibraries.Count();
            return View();
        }
        public async Task<ActionResult> Index3()

        {
            return View(await db.BLibraries.ToListAsync());
        }
       
        // GET: BLibraries
        public async Task<ActionResult> Index2()

        {
            return View(await db.BLibraries.ToListAsync());
        }

        // GET: BLibraries/Details/5

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLibrary BLibrary = await db.BLibraries.FindAsync(id);
            if (BLibrary == null)
            {
                return HttpNotFound();
            }
            return View(BLibrary);
        }

        // GET: BLibraries/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: BLibraries/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Book,Dep")] BLibrary BLibrary)
        {
            if (ModelState.IsValid)
            {
                db.BLibraries.Add(BLibrary);
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "library");
            }

            return View(BLibrary);

        }



        // GET: BLibraries/Edit/5

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLibrary BLibrary = await db.BLibraries.FindAsync(id);
            if (BLibrary == null)
            {
                return HttpNotFound();
            }
            return View(BLibrary);
        }
        // POST: BLibraries/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Book,Dep")] BLibrary BLibrary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(BLibrary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index2", "library");
            }
            return View(BLibrary);
        }
        // GET: BLibraries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BLibrary BLibrary = await db.BLibraries.FindAsync(id);
            if (BLibrary == null)
            {
                return HttpNotFound();
            }
            return View(BLibrary);
        }

        // POST: BLibraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BLibrary BLibrary = await db.BLibraries.FindAsync(id);
            db.BLibraries.Remove(BLibrary);
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
