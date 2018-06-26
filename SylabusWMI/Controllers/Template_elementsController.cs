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
    public class Template_elementsController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Template_elements
        public IQueryable<Template_elements> GetTemplate_elements()
        {
            return db.Template_elements;
        }

        // GET: api/Template_elements/5
        [ResponseType(typeof(Template_elements))]
        public async Task<IHttpActionResult> GetTemplate_elements(int id)
        {
            Template_elements template_elements = await db.Template_elements.FindAsync(id);
            if (template_elements == null)
            {
                return NotFound();
            }

            return Ok(template_elements);
        }

        // PUT: api/Template_elements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTemplate_elements(int id, Template_elements template_elements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != template_elements.Id)
            {
                return BadRequest();
            }

            db.Entry(template_elements).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Template_elementsExists(id))
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

        // POST: api/Template_elements
        [ResponseType(typeof(Template_elements))]
        public async Task<IHttpActionResult> PostTemplate_elements(Template_elements template_elements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Template_elements.Add(template_elements);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Template_elementsExists(template_elements.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = template_elements.Id }, template_elements);
        }

        // DELETE: api/Template_elements/5
        [ResponseType(typeof(Template_elements))]
        public async Task<IHttpActionResult> DeleteTemplate_elements(int id)
        {
            Template_elements template_elements = await db.Template_elements.FindAsync(id);
            if (template_elements == null)
            {
                return NotFound();
            }

            db.Template_elements.Remove(template_elements);
            await db.SaveChangesAsync();

            return Ok(template_elements);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Template_elementsExists(int id)
        {
            return db.Template_elements.Count(e => e.Id == id) > 0;
        }
    }
}