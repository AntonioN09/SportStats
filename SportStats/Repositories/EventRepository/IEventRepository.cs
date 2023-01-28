using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.EventRepository
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        public Task<List<Event>> FindRange(List<Guid> eventsIds);
    }
}
