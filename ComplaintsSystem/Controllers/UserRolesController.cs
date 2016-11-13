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
    public class UserRolesController : ApiController
    {
        private ComplaintsDbContext db = new ComplaintsDbContext();

        // GET: api/UserRoles
        public IQueryable<UserRoles> GetuserRoles()
        {
            return db.userRoles;
        }

        // GET: api/UserRoles/5
        [ResponseType(typeof(UserRoles))]
        public IHttpActionResult GetUserRoles(int id)
        {
            UserRoles userRoles = db.userRoles.Find(id);
            if (userRoles == null)
            {
                return NotFound();
            }

            return Ok(userRoles);
        }

        // PUT: api/UserRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserRoles(int id, UserRoles userRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRoles.RoleId)
            {
                return BadRequest();
            }

            db.Entry(userRoles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolesExists(id))
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

        // POST: api/UserRoles
        [ResponseType(typeof(UserRoles))]
        public IHttpActionResult PostUserRoles(UserRoles userRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userRoles.Add(userRoles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userRoles.RoleId }, userRoles);
        }

        // DELETE: api/UserRoles/5
        [ResponseType(typeof(UserRoles))]
        public IHttpActionResult DeleteUserRoles(int id)
        {
            UserRoles userRoles = db.userRoles.Find(id);
            if (userRoles == null)
            {
                return NotFound();
            }

            db.userRoles.Remove(userRoles);
            db.SaveChanges();

            return Ok(userRoles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserRolesExists(int id)
        {
            return db.userRoles.Count(e => e.RoleId == id) > 0;
        }
    }
}