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
    public class Elementy_templateController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Elementy_template
        public IQueryable<Elementy_template> GetElementy_template()
        {
            return db.Elementy_template;
        }

        // GET: api/Elementy_template/5
        [ResponseType(typeof(Elementy_template))]
        public async Task<IHttpActionResult> GetElementy_template(int id)
        {
            Elementy_template elementy_template = await db.Elementy_template.FindAsync(id);
            if (elementy_template == null)
            {
                return NotFound();
            }

            return Ok(elementy_template);
        }

        // PUT: api/Elementy_template/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElementy_template(int id, Elementy_template elementy_template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elementy_template.Id)
            {
                return BadRequest();
            }

            db.Entry(elementy_template).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Elementy_templateExists(id))
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

        // POST: api/Elementy_template
        [ResponseType(typeof(Elementy_template))]
        public async Task<IHttpActionResult> PostElementy_template(Elementy_template elementy_template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elementy_template.Add(elementy_template);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Elementy_templateExists(elementy_template.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elementy_template.Id }, elementy_template);
        }

        // DELETE: api/Elementy_template/5
        [ResponseType(typeof(Elementy_template))]
        public async Task<IHttpActionResult> DeleteElementy_template(int id)
        {
            Elementy_template elementy_template = await db.Elementy_template.FindAsync(id);
            if (elementy_template == null)
            {
                return NotFound();
            }

            db.Elementy_template.Remove(elementy_template);
            await db.SaveChangesAsync();

            return Ok(elementy_template);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Elementy_templateExists(int id)
        {
            return db.Elementy_template.Count(e => e.Id == id) > 0;
        }
    }
}