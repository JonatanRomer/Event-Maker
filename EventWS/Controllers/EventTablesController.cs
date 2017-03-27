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
using EventWS;

namespace EventWS.Controllers
{
    public class EventTablesController : ApiController
    {
        private EventContext db = new EventContext();

        // GET: api/EventTables
        public IQueryable<EventTable> GetEventTable()
        {
            return db.EventTable;
        }

        // GET: api/EventTables/5
        [ResponseType(typeof(EventTable))]
        public IHttpActionResult GetEventTable(int id)
        {
            EventTable eventTable = db.EventTable.Find(id);
            if (eventTable == null)
            {
                return NotFound();
            }

            return Ok(eventTable);
        }

        // PUT: api/EventTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventTable(int id, EventTable eventTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTable.Id)
            {
                return BadRequest();
            }

            db.Entry(eventTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTableExists(id))
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

        // POST: api/EventTables
        [ResponseType(typeof(EventTable))]
        public IHttpActionResult PostEventTable(EventTable eventTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventTable.Add(eventTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EventTableExists(eventTable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eventTable.Id }, eventTable);
        }

        // DELETE: api/EventTables/5
        [ResponseType(typeof(EventTable))]
        public IHttpActionResult DeleteEventTable(int id)
        {
            EventTable eventTable = db.EventTable.Find(id);
            if (eventTable == null)
            {
                return NotFound();
            }

            db.EventTable.Remove(eventTable);
            db.SaveChanges();

            return Ok(eventTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventTableExists(int id)
        {
            return db.EventTable.Count(e => e.Id == id) > 0;
        }
    }
}