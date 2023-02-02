using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStats.Data;
using SportStats.Models;
using SportStats.Services.PlayerService;

namespace SportStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private SportStatsContext _sportStatsContext;
        private readonly IPlayerService _playerService;

        public PlayerController(SportStatsContext sportStatsContext, IPlayerService playerService)
        {
            _sportStatsContext = sportStatsContext;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(await _sportStatsContext.Players.ToListAsync());
        }

        [HttpGet("playerById{id}")]
        public async Task<IActionResult> GetPlayerById([FromRoute] Guid id)
        {
            var playerById = from player in _sportStatsContext.Players
                             where player.Id == id
                             select player;

            return Ok(playerById);
        }

        [HttpPost("CreatePlayer")]
        public async Task<IActionResult> CreatePlayer(Player player)
        {
            var newPlayer = new Player();

            newPlayer.Name = player.Name;
            newPlayer.Rating = player.Rating;
            newPlayer.Awards = player.Awards;
            newPlayer.Skill = player.Skill;
            newPlayer.Cooperation = player.Cooperation;

            await _sportStatsContext.AddAsync(newPlayer);
            await _sportStatsContext.SaveChangesAsync();
            return Ok(newPlayer);
        }
    }
}
