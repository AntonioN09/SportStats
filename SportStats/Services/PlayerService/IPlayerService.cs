using SportStats.Models;

namespace SportStats.Services.PlayerService
{
    public interface IPlayerService
    {
        public Task<List<Player>> GetAll();
        public Task AddPlayer(Player newPlayer);
        public Task DeletePlayer(Guid playerId);
    }
}
