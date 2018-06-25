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
    public class Wartosc_ElementuController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Wartosc_Elementu
        public IQueryable<Wartosc_Elementu> GetWartosc_Elementu()
        {
            return db.Wartosc_Elementu;
        }

        // GET: api/Wartosc_Elementu/5
        [ResponseType(typeof(Wartosc_Elementu))]
        public async Task<IHttpActionResult> GetWartosc_Elementu(int id)
        {
            Wartosc_Elementu wartosc_Elementu = await db.Wartosc_Elementu.FindAsync(id);
            if (wartosc_Elementu == null)
            {
                return NotFound();
            }

            return Ok(wartosc_Elementu);
        }

        // PUT: api/Wartosc_Elementu/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWartosc_Elementu(int id, Wartosc_Elementu wartosc_Elementu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wartosc_Elementu.Id_wartosci)
            {
                return BadRequest();
            }

            db.Entry(wartosc_Elementu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Wartosc_ElementuExists(id))
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

        // POST: api/Wartosc_Elementu
        [ResponseType(typeof(Wartosc_Elementu))]
        public async Task<IHttpActionResult> PostWartosc_Elementu(Wartosc_Elementu wartosc_Elementu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wartosc_Elementu.Add(wartosc_Elementu);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Wartosc_ElementuExists(wartosc_Elementu.Id_wartosci))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wartosc_Elementu.Id_wartosci }, wartosc_Elementu);
        }

        // DELETE: api/Wartosc_Elementu/5
        [ResponseType(typeof(Wartosc_Elementu))]
        public async Task<IHttpActionResult> DeleteWartosc_Elementu(int id)
        {
            Wartosc_Elementu wartosc_Elementu = await db.Wartosc_Elementu.FindAsync(id);
            if (wartosc_Elementu == null)
            {
                return NotFound();
            }

            db.Wartosc_Elementu.Remove(wartosc_Elementu);
            await db.SaveChangesAsync();

            return Ok(wartosc_Elementu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Wartosc_ElementuExists(int id)
        {
            return db.Wartosc_Elementu.Count(e => e.Id_wartosci == id) > 0;
        }
    }
}