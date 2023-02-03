using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Services.EventService;

namespace SportStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private SportStatsContext _sportStatsContext;
        private readonly IEventService _eventService;

        public EventController(SportStatsContext sportStatsContext, IEventService eventService)
        {
            _sportStatsContext = sportStatsContext;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(await _sportStatsContext.Events.ToListAsync());
        }

        //Read
        [HttpGet("eventById{id}")]
        public async Task<IActionResult> GetEventById([FromRoute] Guid id)
        {
            var eventById = from eventt in _sportStatsContext.Events
                            where eventt.Id == id
                            select eventt;

            return Ok(eventById);
        }

        //Create
        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent(Event eventt)
        {
            var newEvent = new Event();

            newEvent.Name = eventt.Name;
            newEvent.Rating = eventt.Rating;
            newEvent.Awards = eventt.Awards;
            newEvent.Location = eventt.Location;
            newEvent.Summary = eventt.Summary;

            await _sportStatsContext.AddAsync(newEvent);
            await _sportStatsContext.SaveChangesAsync();
            return Ok(newEvent);
        }

        //Update
        [HttpPost("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(Event eventt)
        {
            var newEvent = _sportStatsContext.Events.First(m => m.Id == eventt.Id);

            newEvent.Name = eventt.Name;
            newEvent.Rating = eventt.Rating;
            newEvent.Awards = eventt.Awards;
            newEvent.Location = eventt.Location;
            newEvent.Summary = eventt.Summary;

            await _sportStatsContext.SaveChangesAsync();
            return Ok(newEvent);
        }

        //Delete
        [HttpDelete("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(Event eventt)
        {
            _sportStatsContext.Events.Remove(eventt);

            return Ok(await _sportStatsContext.SaveChangesAsync());
        }
    }
}
