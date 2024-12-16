using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserBusinessService _userBusinessService;

        public UserController(UserBusinessService userBusinessService)
        {
            _userBusinessService = userBusinessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userBusinessService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userBusinessService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(int userId, string username, string email, string password, string? role = null)
        {
            var success = await _userBusinessService.UpdateUserAsync(userId, username, email, password, role);
            if (success)
            {
                return Ok("User updated successfully.");
            }
            return StatusCode(500, "Failed to update user.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userBusinessService.DeleteUserAsync(id);
            if (success)
                return Ok("User deleted successfully");
            return StatusCode(500, "Failed to delete user");
        }

        // POST: /api/User/AddViaFunction
        [HttpPost("AddViaFunction")]
        public async Task<IActionResult> AddUserViaFunction(string username, string email, string password)
        {
            var success = await _userBusinessService.AddUserViaFunctionAsync(username, email, password);
            if (success)
            {
                return Ok("User added successfully via database function.");
            }
            return StatusCode(500, "Failed to add user via database function.");
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Email and password must be provided.");
            }

            var user = await _userBusinessService.GetUserByEmailAsync(email);
            if (user == null || user.Password != password)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(new
            {
                userId = user.UserId,
                username = user.Username,
                email = user.Email,
                role = user.Role
            });
        }


    }
}