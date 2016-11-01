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
    public class TicketStatusController : ApiController
    {
        private ComplaintsDbContext db = new ComplaintsDbContext();

        // GET: api/TicketStatus
        public IQueryable<TicketStatus> GetticketStatus()
        {
            return db.ticketStatus;
        }

        // GET: api/TicketStatus/5
        [ResponseType(typeof(TicketStatus))]
        public IHttpActionResult GetTicketStatus(int id)
        {
            TicketStatus ticketStatus = db.ticketStatus.Find(id);
            if (ticketStatus == null)
            {
                return NotFound();
            }

            return Ok(ticketStatus);
        }

        // PUT: api/TicketStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicketStatus(int id, TicketStatus ticketStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketStatus.StatusId)
            {
                return BadRequest();
            }

            db.Entry(ticketStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketStatusExists(id))
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

        // POST: api/TicketStatus
        [ResponseType(typeof(TicketStatus))]
        public IHttpActionResult PostTicketStatus(TicketStatus ticketStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ticketStatus.Add(ticketStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ticketStatus.StatusId }, ticketStatus);
        }

        // DELETE: api/TicketStatus/5
        [ResponseType(typeof(TicketStatus))]
        public IHttpActionResult DeleteTicketStatus(int id)
        {
            TicketStatus ticketStatus = db.ticketStatus.Find(id);
            if (ticketStatus == null)
            {
                return NotFound();
            }

            db.ticketStatus.Remove(ticketStatus);
            db.SaveChanges();

            return Ok(ticketStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketStatusExists(int id)
        {
            return db.ticketStatus.Count(e => e.StatusId == id) > 0;
        }
    }
}