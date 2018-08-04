using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Elements_in_templateController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Elements_in_template
        public IQueryable<Elements_in_template> GetElements_in_template()
        {
            return db.Elements_in_template;
        }

        // GET: api/Elements_in_template/5
        [ResponseType(typeof(Elements_in_template))]
        public IHttpActionResult GetElements_in_template(int id)
        {
            Elements_in_template elements_in_template = db.Elements_in_template.Find(id);
            if (elements_in_template == null)
            {
                return NotFound();
            }

            return Ok(elements_in_template);
        }

        // PUT: api/Elements_in_template/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElements_in_template(int id, Elements_in_template elements_in_template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elements_in_template.Id)
            {
                return BadRequest();
            }

            db.Entry(elements_in_template).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Elements_in_templateExists(id))
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

        // POST: api/Elements_in_template
        [ResponseType(typeof(Elements_in_template))]
        public IHttpActionResult PostElements_in_template(Elements_in_template elements_in_template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elements_in_template.Add(elements_in_template);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = elements_in_template.Id }, elements_in_template);
        }

        // DELETE: api/Elements_in_template/5
        [ResponseType(typeof(Elements_in_template))]
        public IHttpActionResult DeleteElements_in_template(int id)
        {
            Elements_in_template elements_in_template = db.Elements_in_template.Find(id);
            if (elements_in_template == null)
            {
                return NotFound();
            }

            db.Elements_in_template.Remove(elements_in_template);
            db.SaveChanges();

            return Ok(elements_in_template);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Elements_in_templateExists(int id)
        {
            return db.Elements_in_template.Count(e => e.Id == id) > 0;
        }
    }
}