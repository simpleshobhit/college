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
using ComplaintsSystem.Models;

namespace ComplaintsSystem.Controllers
{
    public class TicketsController : ApiController
    {
        private ComplaintsDbContext db = new ComplaintsDbContext();

        // GET: api/Tickets
        public IQueryable<Tickets> Gettickets()
        {
            return db.tickets;
        }

        // GET: api/Tickets/5
        [ResponseType(typeof(Tickets))]
        public IHttpActionResult GetTickets(int id)
        {
            Tickets tickets = db.tickets.Find(id);
            if (tickets == null)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

        // PUT: api/Tickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTickets(int id, Tickets tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tickets.ID)
            {
                return BadRequest();
            }

            db.Entry(tickets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsExists(id))
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

        // POST: api/Tickets
        [ResponseType(typeof(Tickets))]
        public IHttpActionResult PostTickets(Tickets tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tickets.Add(tickets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tickets.ID }, tickets);
        }

        // DELETE: api/Tickets/5
        [ResponseType(typeof(Tickets))]
        public IHttpActionResult DeleteTickets(int id)
        {
            Tickets tickets = db.tickets.Find(id);
            if (tickets == null)
            {
                return NotFound();
            }

            db.tickets.Remove(tickets);
            db.SaveChanges();

            return Ok(tickets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketsExists(int id)
        {
            return db.tickets.Count(e => e.ID == id) > 0;
        }
    }
}