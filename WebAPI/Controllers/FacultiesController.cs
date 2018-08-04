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
    public class FacultiesController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Faculties
        public IQueryable<Faculty> GetFaculty()
        {
            return db.Faculty;
        }

        // GET: api/Faculties/5
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult GetFaculty(int id)
        {
            Faculty faculty = db.Faculty.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        // PUT: api/Faculties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFaculty(int id, Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculty.Id_faculty)
            {
                return BadRequest();
            }

            db.Entry(faculty).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyExists(id))
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

        // POST: api/Faculties
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult PostFaculty(Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faculty.Add(faculty);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FacultyExists(faculty.Id_faculty))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = faculty.Id_faculty }, faculty);
        }

        // DELETE: api/Faculties/5
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult DeleteFaculty(int id)
        {
            Faculty faculty = db.Faculty.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }

            db.Faculty.Remove(faculty);
            db.SaveChanges();

            return Ok(faculty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacultyExists(int id)
        {
            return db.Faculty.Count(e => e.Id_faculty == id) > 0;
        }
    }
}