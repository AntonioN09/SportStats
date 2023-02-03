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

        //Read
        [HttpGet("teamById{id}")]
        public async Task<IActionResult> GetTeamById([FromRoute] Guid id)
        {
            var teamById = from team in _sportStatsContext.Teams
                              where team.Id == id
                              select team;

            return Ok(teamById);
        }

        //Create
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

        //Update
        [HttpPost("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam(Team team)
        {
            var newTeam = _sportStatsContext.Teams.First(m => m.Id == team.Id);

            newTeam.Name = team.Name;
            newTeam.Rating = team.Rating;
            newTeam.Awards = team.Awards;
            newTeam.Location = team.Location;
            newTeam.Prestige = team.Prestige;

            await _sportStatsContext.SaveChangesAsync();
            return Ok(newTeam);
        }

        //Delete
        [HttpDelete("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(Team team)
        {
            _sportStatsContext.Teams.Remove(team);

            return Ok(await _sportStatsContext.SaveChangesAsync());
        }
    }
}
