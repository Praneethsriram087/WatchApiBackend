using Microsoft.AspNetCore.Mvc;
using WatchApiBackend.Models;
using WatchApiBackend.Services;

namespace WatchApiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(Team team)
        {
            try
            {
                var success = await _teamService.CreateUser(team);
                return Ok(new { message = "Registration Successful" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "User already exists")
                    return Conflict(new { message = ex.Message });
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                await _teamService.LoginUser(login.Email, login.Password);
                return Ok(new { message = "Login Successful" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "User not found")
                    return NotFound(new { message = ex.Message });
                if (ex.Message == "Incorrect Password")
                    return Unauthorized(new { message = ex.Message });
                return StatusCode(500, new { message = "An error occurred: " + ex.Message });
            }
        }
    }
}
