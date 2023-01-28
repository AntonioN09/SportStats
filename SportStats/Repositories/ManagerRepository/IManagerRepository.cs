using SportStats.Models;
using SportStats.Repositories.GenericRepository;

namespace SportStats.Repositories.ManagerRepository
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        public Task<List<Manager>> FindRange(List<Guid> managersIds);
    }
}
