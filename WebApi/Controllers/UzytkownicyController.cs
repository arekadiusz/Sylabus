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
    public class UzytkownicyController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Uzytkownicy
        public IQueryable<Uzytkownicy> GetUzytkownicies()
        {
            return db.Uzytkownicies;
        }

        // GET: api/Uzytkownicy/5
        [ResponseType(typeof(Uzytkownicy))]
        public IHttpActionResult GetUzytkownicy(int id)
        {
            Uzytkownicy uzytkownicy = db.Uzytkownicies.Find(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return Ok(uzytkownicy);
        }

        // PUT: api/Uzytkownicy/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUzytkownicy(int id, Uzytkownicy uzytkownicy)
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
                db.SaveChanges();
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

        // POST: api/Uzytkownicy
        [ResponseType(typeof(Uzytkownicy))]
        public IHttpActionResult PostUzytkownicy(Uzytkownicy uzytkownicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Uzytkownicies.Add(uzytkownicy);

            try
            {
                db.SaveChanges();
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

        // DELETE: api/Uzytkownicy/5
        [ResponseType(typeof(Uzytkownicy))]
        public IHttpActionResult DeleteUzytkownicy(int id)
        {
            Uzytkownicy uzytkownicy = db.Uzytkownicies.Find(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            db.Uzytkownicies.Remove(uzytkownicy);
            db.SaveChanges();

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