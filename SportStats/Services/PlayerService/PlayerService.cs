using AutoMapper;
using SportStats.Models;
using SportStats.Repositories.PlayerRepository;
using SportStats.Services.PlayerService;

namespace SportStats.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        public IPlayerRepository _playerRepository;
        public IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<List<Player>> GetAll()
        {
            var players = await _playerRepository.GetAll();
            return _mapper.Map<List<Player>>(players);
        }

        public async Task AddPlayer(Player newPlayer)
        {
            var newDbPlayer = _mapper.Map<Player>(newPlayer);
            await _playerRepository.CreateAsync(newDbPlayer);
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
