using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.EventRepository
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(SportStatsContext context) : base(context) { }

        public async Task<List<Event>> FindRange(List<Guid> eventsIds)
        {
            return await _table.Where(x => eventsIds.Contains(x.Id)).ToListAsync();
        }
    }
}
