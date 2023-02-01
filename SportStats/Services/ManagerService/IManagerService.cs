using SportStats.Models;

namespace SportStats.Services.ManagerService
{
    public interface IManagerService
    {
        public Task<List<Manager>> GetAll();
        public Task AddManager(Manager newManager);
        public Task DeleteManager(Guid managerId);
    }
}
