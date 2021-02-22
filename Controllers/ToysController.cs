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
using ToysWebAPI.Data;
using ToysWebAPI.Models;

namespace ToysWebAPI.Controllers
{
    public class ToysController : ApiController
    {
        private ToysWebAPIContext db = new ToysWebAPIContext();

        // GET: api/Toys
        public IQueryable<Toy> GetToys()
        {
            return db.Toys;
        }

        // GET: api/Toys/5
        [ResponseType(typeof(Toy))]
        public IHttpActionResult GetToy(int id)
        {
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return NotFound();
            }

            return Ok(toy);
        }

        // PUT: api/Toys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToy(int id, Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toy.ToyId)
            {
                return BadRequest();
            }

            db.Entry(toy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToyExists(id))
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

        // POST: api/Toys
        [ResponseType(typeof(Toy))]
        public IHttpActionResult PostToy(Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Toys.Add(toy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toy.ToyId }, toy);
        }

        // DELETE: api/Toys/5
        [ResponseType(typeof(Toy))]
        public IHttpActionResult DeleteToy(int id)
        {
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return NotFound();
            }

            db.Toys.Remove(toy);
            db.SaveChanges();

            return Ok(toy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToyExists(int id)
        {
            return db.Toys.Count(e => e.ToyId == id) > 0;
        }
    }
}