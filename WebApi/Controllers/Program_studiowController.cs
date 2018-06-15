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
    public class Program_studiowController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Program_studiow
        public IQueryable<Program_studiow> GetProgram_studiow()
        {
            return db.Program_studiow;
        }

        // GET: api/Program_studiow/5
        [ResponseType(typeof(Program_studiow))]
        public IHttpActionResult GetProgram_studiow(string id)
        {
            Program_studiow program_studiow = db.Program_studiow.Find(id);
            if (program_studiow == null)
            {
                return NotFound();
            }

            return Ok(program_studiow);
        }

        // PUT: api/Program_studiow/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgram_studiow(string id, Program_studiow program_studiow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != program_studiow.Kod_przedmiotu)
            {
                return BadRequest();
            }

            db.Entry(program_studiow).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Program_studiowExists(id))
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

        // POST: api/Program_studiow
        [ResponseType(typeof(Program_studiow))]
        public IHttpActionResult PostProgram_studiow(Program_studiow program_studiow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Program_studiow.Add(program_studiow);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Program_studiowExists(program_studiow.Kod_przedmiotu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = program_studiow.Kod_przedmiotu }, program_studiow);
        }

        // DELETE: api/Program_studiow/5
        [ResponseType(typeof(Program_studiow))]
        public IHttpActionResult DeleteProgram_studiow(string id)
        {
            Program_studiow program_studiow = db.Program_studiow.Find(id);
            if (program_studiow == null)
            {
                return NotFound();
            }

            db.Program_studiow.Remove(program_studiow);
            db.SaveChanges();

            return Ok(program_studiow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Program_studiowExists(string id)
        {
            return db.Program_studiow.Count(e => e.Kod_przedmiotu == id) > 0;
        }
    }
}