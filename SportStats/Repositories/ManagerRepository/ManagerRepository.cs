using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.ManagerRepository
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(SportStatsContext context) : base(context) { }

        public async Task<List<Manager>> FindRange(List<Guid> managersIds)
        {
            return await _table.Where(x => managersIds.Contains(x.Id)).ToListAsync();
        }
    }
}
