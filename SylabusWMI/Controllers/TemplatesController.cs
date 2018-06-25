using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SylabusWMI.Models;

namespace SylabusWMI.Controllers
{
    public class TemplatesController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Templates
        public IQueryable<Template> GetTemplates()
        {
            return db.Templates;
        }

        // GET: api/Templates/5
        [ResponseType(typeof(Template))]
        public async Task<IHttpActionResult> GetTemplate(string id)
        {
            Template template = await db.Templates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            return Ok(template);
        }

        // PUT: api/Templates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTemplate(string id, Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != template.Kod_template)
            {
                return BadRequest();
            }

            db.Entry(template).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Templates
        [ResponseType(typeof(Template))]
        public async Task<IHttpActionResult> PostTemplate(Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Templates.Add(template);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TemplateExists(template.Kod_template))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = template.Kod_template }, template);
        }

        // DELETE: api/Templates/5
        [ResponseType(typeof(Template))]
        public async Task<IHttpActionResult> DeleteTemplate(string id)
        {
            Template template = await db.Templates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            db.Templates.Remove(template);
            await db.SaveChangesAsync();

            return Ok(template);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TemplateExists(string id)
        {
            return db.Templates.Count(e => e.Kod_template == id) > 0;
        }
    }
}