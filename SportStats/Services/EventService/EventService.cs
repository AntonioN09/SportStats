using AutoMapper;
using SportStats.Models;
using SportStats.Repositories.EventRepository;
using SportStats.Services.EventService;

namespace SportStats.Services.EventService
{
    public class EventService : IEventService
    {
        public IEventRepository _eventRepository;
        public IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<Event>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            return _mapper.Map<List<Event>>(events);
        }

        public async Task AddEvent(Event newEvent)
        {
            var newDbEvent = _mapper.Map<Event>(newEvent);
            await _eventRepository.CreateAsync(newDbEvent);
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
