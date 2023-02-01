using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.TeamRepository
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        public Task<List<Team>> GetAllWithInclude();

        public Task<List<Team>> GetAllWithJoin();
    }
}
