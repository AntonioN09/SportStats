using SportStats.Models;
using SportStats.Repositories.EventRepository;
using SportStats.Services.EventService;

namespace SportStats.Services.EventService
{
    public class EventService : IEventService
    {
        public IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetAll()
        {
            return await _eventRepository.GetAll();
        }

        public async Task AddEvent(Event newEvent)
        {
            await _eventRepository.CreateAsync(newEvent);
            await _eventRepository.SaveAsync();
        }

        public async Task DeleteEvent(Guid eventId)
        {
            var eventToDelete = await _eventRepository.FindByIdAsync(eventId);
            _eventRepository.Delete(eventToDelete);
            await _eventRepository.SaveAsync();
        }

    }
}
