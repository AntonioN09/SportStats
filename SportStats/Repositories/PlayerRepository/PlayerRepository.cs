using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.PlayerRepository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(SportStatsContext context) : base(context) { }

        public async Task<List<Player>> GetTopPlayers()
        {
            return await _table.OrderBy(x => x.Skill).ToListAsync();
        }
    }
}
