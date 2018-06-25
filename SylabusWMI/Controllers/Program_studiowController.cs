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
        public async Task<IHttpActionResult> GetProgram_studiow(string id)
        {
            Program_studiow program_studiow = await db.Program_studiow.FindAsync(id);
            if (program_studiow == null)
            {
                return NotFound();
            }

            return Ok(program_studiow);
        }

        // PUT: api/Program_studiow/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProgram_studiow(string id, Program_studiow program_studiow)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostProgram_studiow(Program_studiow program_studiow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Program_studiow.Add(program_studiow);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> DeleteProgram_studiow(string id)
        {
            Program_studiow program_studiow = await db.Program_studiow.FindAsync(id);
            if (program_studiow == null)
            {
                return NotFound();
            }

            db.Program_studiow.Remove(program_studiow);
            await db.SaveChangesAsync();

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