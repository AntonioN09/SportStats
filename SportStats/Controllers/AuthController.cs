using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportStats.Helpers.Attributes;
using SportStats.Migrations;
using SportStats.Models.DTOs;
using SportStats.Models.Enums;
using SportStats.Services.ManagerService;

namespace SportStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IManagerService _managerService;

        public AuthController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [Authorization(Role.Admin)]
        [HttpPost("create-manager")]
        public async Task<IActionResult> CreateManager(ManagerAuthRequestDto user)
        {
            await _managerService.Create(user);
            return Ok();
        }

        [Authorization(Role.User)]
        [HttpPost("login-manager")]
        public IActionResult LoginManager(ManagerAuthRequestDto user)
        {
            var response = _managerService.Authenticate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }
    }
}
