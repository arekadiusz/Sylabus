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
using System.Web.Mvc;
using SylabusWMI.Models;

namespace SylabusWMI.Controllers
{
    public class FacultiesController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Faculties
        public IQueryable<Faculty> GetFaculties()
        {
            return db.Faculties;
        }

        // GET: api/Faculties/5
        [ResponseType(typeof(Faculty))]
        public async Task<IHttpActionResult> GetFaculty(int id)
        {
            Faculty faculty = await db.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        // PUT: api/Faculties/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFaculty(int id, Faculty faculty)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostFaculty(Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faculties.Add(faculty);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> DeleteFaculty(int id)
        {
            Faculty faculty = await db.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }

            db.Faculties.Remove(faculty);
            await db.SaveChangesAsync();

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
            return db.Faculties.Count(e => e.Id_faculty == id) > 0;
        }
    }

}