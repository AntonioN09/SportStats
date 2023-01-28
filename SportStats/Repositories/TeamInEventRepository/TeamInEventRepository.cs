using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.TeamInEventRepository
{
    public class TeamInEventRepository : GenericRepository<TeamInEvent>, ITeamInEventRepository
    {
        public TeamInEventRepository(SportStatsContext context) : base(context) { }
    }
}
