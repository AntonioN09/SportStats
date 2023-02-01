using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(SportStatsContext context) : base(context) { }

        public async Task<List<Team>> GetAllWithInclude()
        {
            return await _table.Include(x => x.Players).ToListAsync();
        }

        public async Task<List<Team>> GetAllWithJoin()
        {
            var result = _table.Join(_context.Players, team => team.Id, player => player.TeamId,
                (team, player) => new { team, player }).Select(x => x.team);

            return await result.ToListAsync();
        }


    }
}
