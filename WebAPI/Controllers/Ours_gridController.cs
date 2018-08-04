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
    public class Ours_gridController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Ours_grid
        public IQueryable<Ours_grid> GetOurs_grid()
        {
            return db.Ours_grid;
        }

        // GET: api/Ours_grid/5
        [ResponseType(typeof(Ours_grid))]
        public IHttpActionResult GetOurs_grid(string id)
        {
            Ours_grid ours_grid = db.Ours_grid.Find(id);
            if (ours_grid == null)
            {
                return NotFound();
            }

            return Ok(ours_grid);
        }

        // PUT: api/Ours_grid/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOurs_grid(string id, Ours_grid ours_grid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ours_grid.Id_grid)
            {
                return BadRequest();
            }

            db.Entry(ours_grid).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ours_gridExists(id))
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

        // POST: api/Ours_grid
        [ResponseType(typeof(Ours_grid))]
        public IHttpActionResult PostOurs_grid(Ours_grid ours_grid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ours_grid.Add(ours_grid);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ours_gridExists(ours_grid.Id_grid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ours_grid.Id_grid }, ours_grid);
        }

        // DELETE: api/Ours_grid/5
        [ResponseType(typeof(Ours_grid))]
        public IHttpActionResult DeleteOurs_grid(string id)
        {
            Ours_grid ours_grid = db.Ours_grid.Find(id);
            if (ours_grid == null)
            {
                return NotFound();
            }

            db.Ours_grid.Remove(ours_grid);
            db.SaveChanges();

            return Ok(ours_grid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ours_gridExists(string id)
        {
            return db.Ours_grid.Count(e => e.Id_grid == id) > 0;
        }
    }
}