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
    public class UsersController : ApiController
    {
        private ComplaintsDbContext db = new ComplaintsDbContext();

        // GET: api/Users
        public IQueryable<Users> Getusers()
        {
            return db.users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        }
        // POST: api/Users/Login
        [ResponseType(typeof(Users))]
        [HttpGet]
        public IHttpActionResult Login([FromUri]string email,[FromUri]string password)
        {
            var User=db.users.Where(x => x.EmailId == email && x.Password == password);

            if (User.Count() == 0)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
            else
            {
                return Ok(User);
            }
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.users.Count(e => e.Id == id) > 0;
        }
    }
}