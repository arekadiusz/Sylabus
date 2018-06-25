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
    public class UzytkowniciesController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Uzytkownicies
        public IQueryable<Uzytkownicy> GetUzytkownicies()
        {
            return db.Uzytkownicies;
        }

        // GET: api/Uzytkownicies/5
        [ResponseType(typeof(Uzytkownicy))]
        public async Task<IHttpActionResult> GetUzytkownicy(int id)
        {
            Uzytkownicy uzytkownicy = await db.Uzytkownicies.FindAsync(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return Ok(uzytkownicy);
        }

        // PUT: api/Uzytkownicies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUzytkownicy(int id, Uzytkownicy uzytkownicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uzytkownicy.E_mail)
            {
                return BadRequest();
            }

            db.Entry(uzytkownicy).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UzytkownicyExists(id))
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

        // POST: api/Uzytkownicies
        [ResponseType(typeof(Uzytkownicy))]
        public async Task<IHttpActionResult> PostUzytkownicy(Uzytkownicy uzytkownicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Uzytkownicies.Add(uzytkownicy);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UzytkownicyExists(uzytkownicy.E_mail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uzytkownicy.E_mail }, uzytkownicy);
        }

        // DELETE: api/Uzytkownicies/5
        [ResponseType(typeof(Uzytkownicy))]
        public async Task<IHttpActionResult> DeleteUzytkownicy(int id)
        {
            Uzytkownicy uzytkownicy = await db.Uzytkownicies.FindAsync(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            db.Uzytkownicies.Remove(uzytkownicy);
            await db.SaveChangesAsync();

            return Ok(uzytkownicy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UzytkownicyExists(int id)
        {
            return db.Uzytkownicies.Count(e => e.E_mail == id) > 0;
        }
    }
}