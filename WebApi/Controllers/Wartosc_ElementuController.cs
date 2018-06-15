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
        public IHttpActionResult GetWartosc_Elementu(int id)
        {
            Wartosc_Elementu wartosc_Elementu = db.Wartosc_Elementu.Find(id);
            if (wartosc_Elementu == null)
            {
                return NotFound();
            }

            return Ok(wartosc_Elementu);
        }

        // PUT: api/Wartosc_Elementu/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWartosc_Elementu(int id, Wartosc_Elementu wartosc_Elementu)
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
                db.SaveChanges();
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
        public IHttpActionResult PostWartosc_Elementu(Wartosc_Elementu wartosc_Elementu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wartosc_Elementu.Add(wartosc_Elementu);

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult DeleteWartosc_Elementu(int id)
        {
            Wartosc_Elementu wartosc_Elementu = db.Wartosc_Elementu.Find(id);
            if (wartosc_Elementu == null)
            {
                return NotFound();
            }

            db.Wartosc_Elementu.Remove(wartosc_Elementu);
            db.SaveChanges();

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