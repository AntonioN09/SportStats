using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(SportStatsContext context) : base(context) { }

        public async Task<List<Team>> FindRange(List<Guid> teamsIds)
        {
            return await _table.Where(x => teamsIds.Contains(x.Id)).ToListAsync();
        }
    }
}
