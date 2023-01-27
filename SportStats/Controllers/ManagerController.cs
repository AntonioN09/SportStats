using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;

namespace SportStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private SportStatsContext _sportStatsContext;

        public ManagerController(SportStatsContext sportStatsContext)
        {
            _sportStatsContext = sportStatsContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetManagers()
        {
            return Ok(await _sportStatsContext.Managers.ToListAsync());
        }

        [HttpGet("managerById{id}")]
        public async Task<IActionResult> GetManagerById([FromRoute] Guid id)
        {
            var managerById = from manager in _sportStatsContext.Managers
                              where manager.Id == id
                              select manager;

            return Ok(managerById);
        }

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
    }
}
