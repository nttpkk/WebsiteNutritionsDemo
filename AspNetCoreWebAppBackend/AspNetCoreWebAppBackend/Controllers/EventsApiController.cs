using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebAppBackend.Database;

namespace AspNetCoreWebAppBackend.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsApiController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Events> Listing()
        {
            NutritionsDBContext context = new NutritionsDBContext();
            List<Events> allEvents = context.Events.ToList();

            return allEvents;
        }
        [HttpPost]
        [Route("")]
        public bool CreateNewEvent([FromBody] Events newEvent)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            context.Events.Add(newEvent);
            context.SaveChanges();
            return true;
        }

        [HttpPut]
        [Route("{eventID}")]
        public Events ModifyEvent(int eventID, Events updatedEvent)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            Events eventVariable = context.Events.Find(eventID);
            if(eventVariable == null)
            {
                return null;
            }
            eventVariable.EventDate = updatedEvent.EventDate;
            context.SaveChanges();

            return eventVariable;
        }

        [HttpDelete]
        [Route("{eventID}")]
        public bool DeleteEvent(int eventID)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            Events eventVariable = context.Events.Find(eventID);

            if (eventVariable == null)
            {
                return false;
            }

            context.Events.Remove(eventVariable);
            context.SaveChanges();

            return true;
        }


        //private readonly NutritionsDBContext _context;

        //public EventsApiController(NutritionsDBContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/EventsApi
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Events>>> GetEvents()
        //{
        //    return await _context.Events.ToListAsync();
        //}

        //// GET: api/EventsApi/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Events>> GetEvents(int id)
        //{
        //    var events = await _context.Events.FindAsync(id);

        //    if (events == null)
        //    {
        //        return NotFound();
        //    }

        //    return events;
        //}

        //// PUT: api/EventsApi/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEvents(int id, Events events)
        //{
        //    if (id != events.EventId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(events).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/EventsApi
        //[HttpPost]
        //public async Task<ActionResult<Events>> PostEvents(Events events)
        //{
        //    _context.Events.Add(events);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEvents", new { id = events.EventId }, events);
        //}

        //// DELETE: api/EventsApi/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Events>> DeleteEvents(int id)
        //{
        //    var events = await _context.Events.FindAsync(id);
        //    if (events == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Events.Remove(events);
        //    await _context.SaveChangesAsync();

        //    return events;
        //}

        //private bool EventsExists(int id)
        //{
        //    return _context.Events.Any(e => e.EventId == id);
        //}
    }
}
