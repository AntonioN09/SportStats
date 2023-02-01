using AutoMapper;
using SportStats.Models;
using SportStats.Repositories.ManagerRepository;

namespace SportStats.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        public IManagerRepository _managerRepository;
        public IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        public async Task<List<Manager>> GetAll()
        {
            var managers = await _managerRepository.GetAll();
            return _mapper.Map<List<Manager>>(managers);
        }

        public async Task AddManager(Manager newManager)
        {
            var newDbManager = _mapper.Map<Manager>(newManager);
            await _managerRepository.CreateAsync(newDbManager);
            await _managerRepository.SaveAsync();
        }

        public async Task DeleteManager(Guid managerId)
        {
            var managerToDelete = await _managerRepository.FindByIdAsync(managerId);
            _managerRepository.Delete(managerToDelete);
            await _managerRepository.SaveAsync();
        }

    }
}
