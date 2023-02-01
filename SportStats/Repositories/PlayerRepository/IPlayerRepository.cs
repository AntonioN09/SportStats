using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.PlayerRepository
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        public Task<List<Player>> GetTopPlayers();
    }
}
