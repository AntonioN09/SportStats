using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Services.TeamService;

namespace SportStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private SportStatsContext _sportStatsContext;
        private readonly ITeamService _teamService;

        public TeamController(SportStatsContext sportStatsContext, ITeamService teamService)
        {
            _sportStatsContext = sportStatsContext;
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            return Ok(await _sportStatsContext.Teams.ToListAsync());
        }

        [HttpGet("teamById{id}")]
        public async Task<IActionResult> GetTeamById([FromRoute] Guid id)
        {
            var teamById = from team in _sportStatsContext.Teams
                              where team.Id == id
                              select team;

            return Ok(teamById);
        }

        [HttpPost("CreateTeam")]
        public async Task<IActionResult> CreateTeam(Team team)
        {
            var newTeam = new Team();

            newTeam.Name = team.Name;
            newTeam.Rating = team.Rating;
            newTeam.Awards = team.Awards;
            newTeam.Location = team.Location;
            newTeam.Prestige = team.Prestige;

            await _sportStatsContext.AddAsync(newTeam);
            await _sportStatsContext.SaveChangesAsync();
            return Ok(newTeam);
        }
    }
}
