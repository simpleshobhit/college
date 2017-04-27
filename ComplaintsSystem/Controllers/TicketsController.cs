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
using System.Web.Routing;

namespace ComplaintsSystem.Controllers
{
    [RoutePrefix("api/Tickets")]
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

        // GET: api/GetUserTickets/5
        //[ResponseType(typeof(Tickets))]
        [Route("GetUserTickets")]
        [HttpGet]
        public IHttpActionResult GetUserTickets([FromUri]int id)
        {
            var user = db.users.Find(id);
            var tickets = db.tickets;

            if (user.StudentId != null)
            {
                return Ok(tickets.Where(x=>x.StudentId==user.StudentId));
            }
            else if(user.RoleId==3)
            {
                return Ok(tickets.Where(x => x.StatusId==5));
            }
            else if (user.RoleId == 4)
            {
                return Ok(tickets.Where(x => x.StatusId == 6));
            }
            else if (user.RoleId == 5)
            {
                return Ok(tickets.Where(x => x.StatusId == 7 || x.StatusId==2));
            }
            else if (user.RoleId == 6)
            {
                return Ok(tickets.Where(x => x.StatusId == 8));
            }
            else if (user.RoleId == 7)
            {
                return Ok(tickets.Where(x => x.StatusId == 9));
            }
            else if (user.RoleId == 8)
            {
                return Ok(tickets.Where(x => x.StatusId == 10));
            }
            else if (user.RoleId == 2)
            {
                return Ok(tickets);
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