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
        public IHttpActionResult GetTemplate_elements(int id)
        {
            Template_elements template_elements = db.Template_elements.Find(id);
            if (template_elements == null)
            {
                return NotFound();
            }

            return Ok(template_elements);
        }

        // PUT: api/Template_elements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTemplate_elements(int id, Template_elements template_elements)
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
                db.SaveChanges();
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
        public IHttpActionResult PostTemplate_elements(Template_elements template_elements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Template_elements.Add(template_elements);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = template_elements.Id }, template_elements);
        }

        // DELETE: api/Template_elements/5
        [ResponseType(typeof(Template_elements))]
        public IHttpActionResult DeleteTemplate_elements(int id)
        {
            Template_elements template_elements = db.Template_elements.Find(id);
            if (template_elements == null)
            {
                return NotFound();
            }

            db.Template_elements.Remove(template_elements);
            db.SaveChanges();

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