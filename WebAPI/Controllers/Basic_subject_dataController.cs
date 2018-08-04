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
    public class Basic_subject_dataController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Basic_subject_data
        public IQueryable<Basic_subject_data> GetBasic_subject_data()
        {
            return db.Basic_subject_data;
        }

        // GET: api/Basic_subject_data/5
        [ResponseType(typeof(Basic_subject_data))]
        public IHttpActionResult GetBasic_subject_data(string id)
        {
            Basic_subject_data basic_subject_data = db.Basic_subject_data.Find(id);
            if (basic_subject_data == null)
            {
                return NotFound();
            }

            return Ok(basic_subject_data);
        }

        // PUT: api/Basic_subject_data/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBasic_subject_data(string id, Basic_subject_data basic_subject_data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != basic_subject_data.Subject_code)
            {
                return BadRequest();
            }

            db.Entry(basic_subject_data).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Basic_subject_dataExists(id))
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

        // POST: api/Basic_subject_data
        [ResponseType(typeof(Basic_subject_data))]
        public IHttpActionResult PostBasic_subject_data(Basic_subject_data basic_subject_data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Basic_subject_data.Add(basic_subject_data);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Basic_subject_dataExists(basic_subject_data.Subject_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = basic_subject_data.Subject_code }, basic_subject_data);
        }

        // DELETE: api/Basic_subject_data/5
        [ResponseType(typeof(Basic_subject_data))]
        public IHttpActionResult DeleteBasic_subject_data(string id)
        {
            Basic_subject_data basic_subject_data = db.Basic_subject_data.Find(id);
            if (basic_subject_data == null)
            {
                return NotFound();
            }

            db.Basic_subject_data.Remove(basic_subject_data);
            db.SaveChanges();

            return Ok(basic_subject_data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Basic_subject_dataExists(string id)
        {
            return db.Basic_subject_data.Count(e => e.Subject_code == id) > 0;
        }
    }
}