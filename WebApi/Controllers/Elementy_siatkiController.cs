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
    public class Elementy_siatkiController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Elementy_siatki
        public IQueryable<Elementy_siatki> GetElementy_siatki()
        {
            return db.Elementy_siatki;
        }

        // GET: api/Elementy_siatki/5
        [ResponseType(typeof(Elementy_siatki))]
        public IHttpActionResult GetElementy_siatki(int id)
        {
            Elementy_siatki elementy_siatki = db.Elementy_siatki.Find(id);
            if (elementy_siatki == null)
            {
                return NotFound();
            }

            return Ok(elementy_siatki);
        }

        // PUT: api/Elementy_siatki/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElementy_siatki(int id, Elementy_siatki elementy_siatki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elementy_siatki.Id)
            {
                return BadRequest();
            }

            db.Entry(elementy_siatki).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Elementy_siatkiExists(id))
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

        // POST: api/Elementy_siatki
        [ResponseType(typeof(Elementy_siatki))]
        public IHttpActionResult PostElementy_siatki(Elementy_siatki elementy_siatki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elementy_siatki.Add(elementy_siatki);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Elementy_siatkiExists(elementy_siatki.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elementy_siatki.Id }, elementy_siatki);
        }

        // DELETE: api/Elementy_siatki/5
        [ResponseType(typeof(Elementy_siatki))]
        public IHttpActionResult DeleteElementy_siatki(int id)
        {
            Elementy_siatki elementy_siatki = db.Elementy_siatki.Find(id);
            if (elementy_siatki == null)
            {
                return NotFound();
            }

            db.Elementy_siatki.Remove(elementy_siatki);
            db.SaveChanges();

            return Ok(elementy_siatki);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Elementy_siatkiExists(int id)
        {
            return db.Elementy_siatki.Count(e => e.Id == id) > 0;
        }
    }
}