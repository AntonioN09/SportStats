using AutoMapper;
using SportStats.Models;
using SportStats.Repositories.TeamRepository;
using SportStats.Services.TeamService;

namespace SportStats.Services.TeamService
{
    public class TeamService : ITeamService
    {
        public ITeamRepository _teamRepository;
        public IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<List<Team>> GetAll()
        {
            var teams = await _teamRepository.GetAll();
            return _mapper.Map<List<Team>>(teams);
        }

        public async Task AddTeam(Team newTeam)
        {
            var newDbTeam = _mapper.Map<Team>(newTeam);
            await _teamRepository.CreateAsync(newDbTeam);
            await _teamRepository.SaveAsync();
        }

        public async Task DeleteTeam(Guid teamId)
        {
            var teamToDelete = await _teamRepository.FindByIdAsync(teamId);
            _teamRepository.Delete(teamToDelete);
            await _teamRepository.SaveAsync();
        }

    }
}
