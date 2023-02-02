using SportStats.Models;
using SportStats.Models.DTOs;

namespace SportStats.Services.ManagerService
{
    public interface IManagerService
    {
        public Task<List<Manager>> GetAll();
        public Task AddManager(Manager newManager);
        public Task DeleteManager(Guid managerId);
        Task Create(ManagerAuthRequestDto newManager);
        ManagerAuthResponseDto Authenticate(ManagerAuthRequestDto model);
        Manager GetById(Guid id);
    }
}
