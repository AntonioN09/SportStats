using SportStats.Models;

namespace SportStats.Services.EventService
{
    public interface IEventService
    {
        public Task<List<Event>> GetAll();
        public Task AddEvent(Event newEvent);
        public Task DeleteEvent(Guid eventId);
    }
}
