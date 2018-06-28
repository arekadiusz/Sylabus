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
    public class TemplateController : Controller
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: Template
        public async Task<ActionResult> Index()
        {
            var templates = db.Templates.Include(t => t.Faculty);
            return View(await templates.ToListAsync());
        }

        // GET: Template/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template template = await db.Templates.FindAsync(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            return View(template);
        }

        // GET: Template/Create
        public ActionResult Create()
        {
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL");
            return View();
        }

        // POST: Template/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Template_code,Year,Template_name,Faculty")] Template template)
        {
            if (ModelState.IsValid)
            {
                db.Templates.Add(template);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", template.Faculty);
            return View(template);
        }

        // GET: Template/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template template = await db.Templates.FindAsync(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", template.Faculty);
            return View(template);
        }

        // POST: Template/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Template_code,Year,Template_name,Faculty")] Template template)
        {
            if (ModelState.IsValid)
            {
                db.Entry(template).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Faculty = new SelectList(db.Faculties, "Id_faculty", "Name_PL", template.Faculty);
            return View(template);
        }

        // GET: Template/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Template template = await db.Templates.FindAsync(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            return View(template);
        }

        // POST: Template/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Template template = await db.Templates.FindAsync(id);
            db.Templates.Remove(template);
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
