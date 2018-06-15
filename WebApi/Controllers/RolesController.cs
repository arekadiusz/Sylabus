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
    public class RolesController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Roles
        public IQueryable<Role> GetRoles()
        {
            return db.Roles;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(string id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(string id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Nazwa_Roli)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(role);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.Nazwa_Roli))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = role.Nazwa_Roli }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(string id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(string id)
        {
            return db.Roles.Count(e => e.Nazwa_Roli == id) > 0;
        }
    }
}