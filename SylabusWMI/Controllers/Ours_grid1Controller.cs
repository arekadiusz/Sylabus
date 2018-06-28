using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SylabusWMI.Models;

namespace SylabusWMI.Controllers
{
    public class Ours_grid1Controller : Controller
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: Ours_grid1
        public async Task<ActionResult> Index()
        {
            var ours_grid = db.Ours_grid.Include(o => o.Faculty1).Include(o => o.Study_programme1);
            return View(await ours_grid.ToListAsync());
        }

        // GET: Ours_grid1/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ours_grid ours_grid = await db.Ours_grid.FindAsync(id);
            if (ours_grid == null)
            {
                return HttpNotFound();
            }
            return View(ours_grid);
        }

        // GET: Ours_grid1/Create
        public ActionResult Create()
        {
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL");
            ViewBag.Study_programme = new SelectList(db.Study_programme, "Id_study_program", "Study_mode");
            return View();
        }

        // POST: Ours_grid1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_grid,Study_programme,Recruitment_year,Faculty")] Ours_grid ours_grid)
        {
            if (ModelState.IsValid)
            {
                db.Ours_grid.Add(ours_grid);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", ours_grid.Faculty);
            ViewBag.Study_programme = new SelectList(db.Study_programme, "Id_study_program", "Study_mode", ours_grid.Study_programme);
            return View(ours_grid);
        }

        // GET: Ours_grid1/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ours_grid ours_grid = await db.Ours_grid.FindAsync(id);
            if (ours_grid == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", ours_grid.Faculty);
            ViewBag.Study_programme = new SelectList(db.Study_programme, "Id_study_program", "Study_mode", ours_grid.Study_programme);
            return View(ours_grid);
        }

        // POST: Ours_grid1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_grid,Study_programme,Recruitment_year,Faculty")] Ours_grid ours_grid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ours_grid).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", ours_grid.Faculty);
            ViewBag.Study_programme = new SelectList(db.Study_programme, "Id_study_program", "Study_mode", ours_grid.Study_programme);
            return View(ours_grid);
        }

        // GET: Ours_grid1/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ours_grid ours_grid = await db.Ours_grid.FindAsync(id);
            if (ours_grid == null)
            {
                return HttpNotFound();
            }
            return View(ours_grid);
        }

        // POST: Ours_grid1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Ours_grid ours_grid = await db.Ours_grid.FindAsync(id);
            db.Ours_grid.Remove(ours_grid);
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
