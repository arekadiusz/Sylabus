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
    public class SylabusController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Sylabus
        public IQueryable<Sylabus> GetSylabus()
        {
            return db.Sylabus;
        }

        // GET: api/Sylabus/5
        [ResponseType(typeof(Sylabus))]
        public IHttpActionResult GetSylabus(string id)
        {
            Sylabus sylabus = db.Sylabus.Find(id);
            if (sylabus == null)
            {
                return NotFound();
            }

            return Ok(sylabus);
        }

        // PUT: api/Sylabus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSylabus(string id, Sylabus sylabus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sylabus.Subject_code)
            {
                return BadRequest();
            }

            db.Entry(sylabus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SylabusExists(id))
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

        // POST: api/Sylabus
        [ResponseType(typeof(Sylabus))]
        public IHttpActionResult PostSylabus(Sylabus sylabus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sylabus.Add(sylabus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SylabusExists(sylabus.Subject_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sylabus.Subject_code }, sylabus);
        }

        // DELETE: api/Sylabus/5
        [ResponseType(typeof(Sylabus))]
        public IHttpActionResult DeleteSylabus(string id)
        {
            Sylabus sylabus = db.Sylabus.Find(id);
            if (sylabus == null)
            {
                return NotFound();
            }

            db.Sylabus.Remove(sylabus);
            db.SaveChanges();

            return Ok(sylabus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SylabusExists(string id)
        {
            return db.Sylabus.Count(e => e.Subject_code == id) > 0;
        }
    }
}