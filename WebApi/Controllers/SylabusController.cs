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
        public IQueryable<Sylabu> GetSylabus()
        {
            return db.Sylabus;
        }

        // GET: api/Sylabus/5
        [ResponseType(typeof(Sylabu))]
        public IHttpActionResult GetSylabu(string id)
        {
            Sylabu sylabu = db.Sylabus.Find(id);
            if (sylabu == null)
            {
                return NotFound();
            }

            return Ok(sylabu);
        }

        // PUT: api/Sylabus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSylabu(string id, Sylabu sylabu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sylabu.Kod_przedmiotu)
            {
                return BadRequest();
            }

            db.Entry(sylabu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SylabuExists(id))
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
        [ResponseType(typeof(Sylabu))]
        public IHttpActionResult PostSylabu(Sylabu sylabu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sylabus.Add(sylabu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SylabuExists(sylabu.Kod_przedmiotu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sylabu.Kod_przedmiotu }, sylabu);
        }

        // DELETE: api/Sylabus/5
        [ResponseType(typeof(Sylabu))]
        public IHttpActionResult DeleteSylabu(string id)
        {
            Sylabu sylabu = db.Sylabus.Find(id);
            if (sylabu == null)
            {
                return NotFound();
            }

            db.Sylabus.Remove(sylabu);
            db.SaveChanges();

            return Ok(sylabu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SylabuExists(string id)
        {
            return db.Sylabus.Count(e => e.Kod_przedmiotu == id) > 0;
        }
    }
}