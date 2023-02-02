using SportStats.Models;
using SportStats.Repositories.TeamRepository;
using SportStats.Services.TeamService;

namespace SportStats.Services.TeamService
{
    public class TeamService : ITeamService
    {
        public ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<List<Team>> GetAll()
        {
            return await _teamRepository.GetAll();
        }

        public async Task AddTeam(Team newTeam)
        {
            await _teamRepository.CreateAsync(newTeam);
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
