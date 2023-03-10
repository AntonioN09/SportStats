using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Services.ManagerService;

namespace SportStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private SportStatsContext _sportStatsContext;
        private readonly IManagerService _managerService;

        public ManagerController(SportStatsContext sportStatsContext, IManagerService managerService)
        {
            _sportStatsContext = sportStatsContext;
            _managerService = managerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetManagers()
        {
            return Ok(await _sportStatsContext.Managers.ToListAsync());
        }

        //Read
        [HttpGet("managerById{id}")]
        public async Task<IActionResult> GetManagerById([FromRoute] Guid id)
        {
            var managerById = _managerService.GetById(id);

            return Ok(managerById);
        }

        //Create
        [HttpPost("CreateManager")]
        public async Task<IActionResult> CreateManager(Manager manager)
        {
            var newManager = new Manager();

            newManager.Name = manager.Name;
            newManager.Rating = manager.Rating;
            newManager.Awards = manager.Awards;
            newManager.Style = manager.Style;
            newManager.Tactics = manager.Tactics;

            await _sportStatsContext.AddAsync(newManager);
            await _sportStatsContext.SaveChangesAsync();
            return Ok(newManager);
        }

        //Update
        [HttpPost("UpdateManager")]
        public async Task<IActionResult> UpdateManager(Manager manager)
        {
            var newManager = _sportStatsContext.Managers.First(m => m.Id == manager.Id);

            newManager.Name = manager.Name;
            newManager.Rating = manager.Rating;
            newManager.Awards = manager.Awards;
            newManager.Style = manager.Style;
            newManager.Tactics = manager.Tactics;

            await _sportStatsContext.SaveChangesAsync();
            return Ok(newManager);
        }

        //Delete
        [HttpDelete("DeleteManager")]
        public async Task<IActionResult> DeleteManager(Manager manager)
        {
            _sportStatsContext.Managers.Remove(manager);

            return Ok(await _sportStatsContext.SaveChangesAsync());
        }
    }
}
