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
    public class Study_programme1Controller : Controller
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: Study_programme1
        public async Task<ActionResult> Index()
        {
            var study_programme = db.Study_programme.Include(s => s.Faculty1);
            return View(await study_programme.ToListAsync());
        }

        // GET: Study_programme1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_programme study_programme = await db.Study_programme.FindAsync(id);
            if (study_programme == null)
            {
                return HttpNotFound();
            }
            return View(study_programme);
        }

        // GET: Study_programme1/Create
        public ActionResult Create()
        {
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL");
            return View();
        }

        // POST: Study_programme1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_study_program,Faculty,Study_mode,Study_degree,Name_PL,Name_ENG")] Study_programme study_programme)
        {
            if (ModelState.IsValid)
            {
                db.Study_programme.Add(study_programme);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", study_programme.Faculty);
            return View(study_programme);
        }

        // GET: Study_programme1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_programme study_programme = await db.Study_programme.FindAsync(id);
            if (study_programme == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", study_programme.Faculty);
            return View(study_programme);
        }

        // POST: Study_programme1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_study_program,Faculty,Study_mode,Study_degree,Name_PL,Name_ENG")] Study_programme study_programme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study_programme).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", study_programme.Faculty);
            return View(study_programme);
        }

        // GET: Study_programme1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_programme study_programme = await db.Study_programme.FindAsync(id);
            if (study_programme == null)
            {
                return HttpNotFound();
            }
            return View(study_programme);
        }

        // POST: Study_programme1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Study_programme study_programme = await db.Study_programme.FindAsync(id);
            db.Study_programme.Remove(study_programme);
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
