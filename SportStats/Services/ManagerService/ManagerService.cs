using AutoMapper;
using SportStats.Controllers.Jwt;
using SportStats.Models;
using SportStats.Models.DTOs;
using SportStats.Models.Enums;
using SportStats.Repositories.ManagerRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SportStats.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        public IManagerRepository _managerRepository;
        public IJwtUtils _jwtUtils;
        public IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, IJwtUtils jwtUtils, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public async Task<List<Manager>> GetAll()
        {
            return await _managerRepository.GetAll();
        }

        public async Task AddManager(Manager newManager)
        {
            await _managerRepository.CreateAsync(newManager);
            await _managerRepository.SaveAsync();
        }

        public async Task DeleteManager(Guid managerId)
        {
            var managerToDelete = await _managerRepository.FindByIdAsync(managerId);
            _managerRepository.Delete(managerToDelete);
            await _managerRepository.SaveAsync();
        }
        public async Task Create(ManagerAuthRequestDto manager)
        {
            var newDBManager = _mapper.Map<Manager>(manager);
            newDBManager.PasswordHash = BCryptNet.HashPassword(manager.Password);
            newDBManager.Role = Role.User;

            await _managerRepository.CreateAsync(newDBManager);
            await _managerRepository.SaveAsync();
        }

        public ManagerAuthResponseDto Authenticate(ManagerAuthRequestDto model)
        {
            var manager = _managerRepository.FindByName(model.Name);
            if (manager == null || !BCryptNet.Verify(model.Password, manager.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(manager);
            return new ManagerAuthResponseDto(manager, jwtToken);
        }

        public Manager GetById(Guid id)
        {
            return _managerRepository.FindById(id);
        }
    }
}
