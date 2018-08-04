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
    public class Study_programmeController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Study_programme
        public IQueryable<Study_programme> GetStudy_programme()
        {
            return db.Study_programme;
        }

        // GET: api/Study_programme/5
        [ResponseType(typeof(Study_programme))]
        public IHttpActionResult GetStudy_programme(int id)
        {
            Study_programme study_programme = db.Study_programme.Find(id);
            if (study_programme == null)
            {
                return NotFound();
            }

            return Ok(study_programme);
        }

        // PUT: api/Study_programme/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudy_programme(int id, Study_programme study_programme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != study_programme.Id_study_program)
            {
                return BadRequest();
            }

            db.Entry(study_programme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Study_programmeExists(id))
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

        // POST: api/Study_programme
        [ResponseType(typeof(Study_programme))]
        public IHttpActionResult PostStudy_programme(Study_programme study_programme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Study_programme.Add(study_programme);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Study_programmeExists(study_programme.Id_study_program))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = study_programme.Id_study_program }, study_programme);
        }

        // DELETE: api/Study_programme/5
        [ResponseType(typeof(Study_programme))]
        public IHttpActionResult DeleteStudy_programme(int id)
        {
            Study_programme study_programme = db.Study_programme.Find(id);
            if (study_programme == null)
            {
                return NotFound();
            }

            db.Study_programme.Remove(study_programme);
            db.SaveChanges();

            return Ok(study_programme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Study_programmeExists(int id)
        {
            return db.Study_programme.Count(e => e.Id_study_program == id) > 0;
        }
    }
}