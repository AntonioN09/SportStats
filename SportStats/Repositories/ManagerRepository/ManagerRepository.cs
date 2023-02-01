using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.ManagerRepository
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(SportStatsContext context) : base(context) { }

        public void GroupManagers()
        {
            var groupedManagers = from m in _table
                                   group m by m.Tactics;

            foreach (var managerGroup in groupedManagers)
            {
                Console.WriteLine("Manager group: " + managerGroup.Key);
                foreach (Manager m in managerGroup)
                {
                    Console.WriteLine("Manager name: " + m.Name);
                }
            }
        }
    }
}
