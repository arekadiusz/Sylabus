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
    public class Siatka_godzinController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Siatka_godzin
        public IQueryable<Siatka_godzin> GetSiatka_godzin()
        {
            return db.Siatka_godzin;
        }

        // GET: api/Siatka_godzin/5
        [ResponseType(typeof(Siatka_godzin))]
        public async Task<IHttpActionResult> GetSiatka_godzin(string id)
        {
            Siatka_godzin siatka_godzin = await db.Siatka_godzin.FindAsync(id);
            if (siatka_godzin == null)
            {
                return NotFound();
            }

            return Ok(siatka_godzin);
        }

        // PUT: api/Siatka_godzin/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSiatka_godzin(string id, Siatka_godzin siatka_godzin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siatka_godzin.Id_siatki)
            {
                return BadRequest();
            }

            db.Entry(siatka_godzin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Siatka_godzinExists(id))
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

        // POST: api/Siatka_godzin
        [ResponseType(typeof(Siatka_godzin))]
        public async Task<IHttpActionResult> PostSiatka_godzin(Siatka_godzin siatka_godzin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Siatka_godzin.Add(siatka_godzin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Siatka_godzinExists(siatka_godzin.Id_siatki))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = siatka_godzin.Id_siatki }, siatka_godzin);
        }

        // DELETE: api/Siatka_godzin/5
        [ResponseType(typeof(Siatka_godzin))]
        public async Task<IHttpActionResult> DeleteSiatka_godzin(string id)
        {
            Siatka_godzin siatka_godzin = await db.Siatka_godzin.FindAsync(id);
            if (siatka_godzin == null)
            {
                return NotFound();
            }

            db.Siatka_godzin.Remove(siatka_godzin);
            await db.SaveChangesAsync();

            return Ok(siatka_godzin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Siatka_godzinExists(string id)
        {
            return db.Siatka_godzin.Count(e => e.Id_siatki == id) > 0;
        }
    }
}