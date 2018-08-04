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
    public class TemplatesController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Templates
        public IQueryable<Template> GetTemplate()
        {
            return db.Template;
        }

        // GET: api/Templates/5
        [ResponseType(typeof(Template))]
        public IHttpActionResult GetTemplate(string id)
        {
            Template template = db.Template.Find(id);
            if (template == null)
            {
                return NotFound();
            }

            return Ok(template);
        }

        // PUT: api/Templates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTemplate(string id, Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != template.Template_code)
            {
                return BadRequest();
            }

            db.Entry(template).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult PostTemplate(Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Template.Add(template);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TemplateExists(template.Template_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = template.Template_code }, template);
        }

        // DELETE: api/Templates/5
        [ResponseType(typeof(Template))]
        public IHttpActionResult DeleteTemplate(string id)
        {
            Template template = db.Template.Find(id);
            if (template == null)
            {
                return NotFound();
            }

            db.Template.Remove(template);
            db.SaveChanges();

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
            return db.Template.Count(e => e.Template_code == id) > 0;
        }
    }
}