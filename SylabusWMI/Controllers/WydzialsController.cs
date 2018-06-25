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
    public class WydzialsController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Wydzials
        public IQueryable<Wydzial> GetWydzials()
        {
            return db.Wydzials;
        }

        // GET: api/Wydzials/5
        [ResponseType(typeof(Wydzial))]
        public async Task<IHttpActionResult> GetWydzial(int id)
        {
            Wydzial wydzial = await db.Wydzials.FindAsync(id);
            if (wydzial == null)
            {
                return NotFound();
            }

            return Ok(wydzial);
        }

        // PUT: api/Wydzials/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWydzial(int id, Wydzial wydzial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wydzial.Id_jednostki)
            {
                return BadRequest();
            }

            db.Entry(wydzial).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WydzialExists(id))
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

        // POST: api/Wydzials
        [ResponseType(typeof(Wydzial))]
        public async Task<IHttpActionResult> PostWydzial(Wydzial wydzial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wydzials.Add(wydzial);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WydzialExists(wydzial.Id_jednostki))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wydzial.Id_jednostki }, wydzial);
        }

        // DELETE: api/Wydzials/5
        [ResponseType(typeof(Wydzial))]
        public async Task<IHttpActionResult> DeleteWydzial(int id)
        {
            Wydzial wydzial = await db.Wydzials.FindAsync(id);
            if (wydzial == null)
            {
                return NotFound();
            }

            db.Wydzials.Remove(wydzial);
            await db.SaveChangesAsync();

            return Ok(wydzial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WydzialExists(int id)
        {
            return db.Wydzials.Count(e => e.Id_jednostki == id) > 0;
        }
    }
}