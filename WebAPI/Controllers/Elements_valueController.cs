﻿using System;
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
    public class Elements_valueController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Elements_value
        public IQueryable<Elements_value> GetElements_value()
        {
            return db.Elements_value;
        }

        // GET: api/Elements_value/5
        [ResponseType(typeof(Elements_value))]
        public IHttpActionResult GetElements_value(int id)
        {
            Elements_value elements_value = db.Elements_value.Find(id);
            if (elements_value == null)
            {
                return NotFound();
            }

            return Ok(elements_value);
        }

        // PUT: api/Elements_value/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElements_value(int id, Elements_value elements_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elements_value.Id_value)
            {
                return BadRequest();
            }

            db.Entry(elements_value).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Elements_valueExists(id))
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

        // POST: api/Elements_value
        [ResponseType(typeof(Elements_value))]
        public IHttpActionResult PostElements_value(Elements_value elements_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elements_value.Add(elements_value);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = elements_value.Id_value }, elements_value);
        }

        // DELETE: api/Elements_value/5
        [ResponseType(typeof(Elements_value))]
        public IHttpActionResult DeleteElements_value(int id)
        {
            Elements_value elements_value = db.Elements_value.Find(id);
            if (elements_value == null)
            {
                return NotFound();
            }

            db.Elements_value.Remove(elements_value);
            db.SaveChanges();

            return Ok(elements_value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Elements_valueExists(int id)
        {
            return db.Elements_value.Count(e => e.Id_value == id) > 0;
        }
    }
}