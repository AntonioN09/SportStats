using SportStats.Models;
using SportStats.Repositories.PlayerRepository;
using SportStats.Services.PlayerService;

namespace SportStats.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        public IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> GetAll()
        {
            return await _playerRepository.GetAll();
        }

        public async Task AddPlayer(Player newPlayer)
        {
            await _playerRepository.CreateAsync(newPlayer);
            await _playerRepository.SaveAsync();
        }

        public async Task DeletePlayer(Guid playerId)
        {
            var playerToDelete = await _playerRepository.FindByIdAsync(playerId);
            _playerRepository.Delete(playerToDelete);
            await _playerRepository.SaveAsync();
        }

    }
}
