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
    public class ComplaintTypesController : ApiController
    {
        private ComplaintsDbContext db = new ComplaintsDbContext();

        // GET: api/ComplaintTypes
        public IQueryable<ComplaintTypes> GetcomplaintType()
        {
            return db.complaintType;
        }

        // GET: api/ComplaintTypes/5
        [ResponseType(typeof(ComplaintTypes))]
        public IHttpActionResult GetComplaintTypes(int id)
        {
            ComplaintTypes complaintTypes = db.complaintType.Find(id);
            if (complaintTypes == null)
            {
                return NotFound();
            }

            return Ok(complaintTypes);
        }

        // PUT: api/ComplaintTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComplaintTypes(int id, ComplaintTypes complaintTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complaintTypes.ComplaintTypeId)
            {
                return BadRequest();
            }

            db.Entry(complaintTypes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplaintTypesExists(id))
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

        // POST: api/ComplaintTypes
        [ResponseType(typeof(ComplaintTypes))]
        public IHttpActionResult PostComplaintTypes(ComplaintTypes complaintTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.complaintType.Add(complaintTypes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = complaintTypes.ComplaintTypeId }, complaintTypes);
        }

        // DELETE: api/ComplaintTypes/5
        [ResponseType(typeof(ComplaintTypes))]
        public IHttpActionResult DeleteComplaintTypes(int id)
        {
            ComplaintTypes complaintTypes = db.complaintType.Find(id);
            if (complaintTypes == null)
            {
                return NotFound();
            }

            db.complaintType.Remove(complaintTypes);
            db.SaveChanges();

            return Ok(complaintTypes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplaintTypesExists(int id)
        {
            return db.complaintType.Count(e => e.ComplaintTypeId == id) > 0;
        }
    }
}