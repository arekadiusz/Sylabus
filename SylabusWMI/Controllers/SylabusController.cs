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
        public async Task<IHttpActionResult> GetSylabu(string id)
        {
            Sylabu sylabu = await db.Sylabus.FindAsync(id);
            if (sylabu == null)
            {
                return NotFound();
            }

            return Ok(sylabu);
        }

        // PUT: api/Sylabus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSylabu(string id, Sylabu sylabu)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostSylabu(Sylabu sylabu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sylabus.Add(sylabu);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> DeleteSylabu(string id)
        {
            Sylabu sylabu = await db.Sylabus.FindAsync(id);
            if (sylabu == null)
            {
                return NotFound();
            }

            db.Sylabus.Remove(sylabu);
            await db.SaveChangesAsync();

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