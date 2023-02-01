using SportStats.Models;

namespace SportStats.Services.TeamService
{
    public interface ITeamService
    {
        public Task<List<Team>> GetAll();
        public Task AddTeam(Team newTeam);
        public Task DeleteTeam(Guid teamId);
    }
}
