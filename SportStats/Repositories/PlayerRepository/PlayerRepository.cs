using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.PlayerRepository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(SportStatsContext context) : base(context) { }

        public async Task<List<Player>> FindRange(List<Guid> playersIds)
        {
            return await _table.Where(x => playersIds.Contains(x.Id)).ToListAsync();
        }
    }
}
