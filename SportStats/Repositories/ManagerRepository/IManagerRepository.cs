using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.ManagerRepository
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        public void GroupManagers();
        Manager FindByName(string name);
    }
}
