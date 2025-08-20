using ExamOnline.Interfaces.IUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO.PassWord != registerDTO.ReTypePassWord)
            {
                return BadRequest("Password isn't equals.");
            }
            var createdUser = await _userService.RegisterAsync(registerDTO);
            return Ok(createdUser);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            
            var token = await _userService.LoginAsync(loginDTO);

            if (token == null)
                return Unauthorized("Invalid username or password.");

            return Ok(new
            {
                Message = "Login successful.",
                Token = token
            });
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "user, teacher, admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO == null)
            {
                return BadRequest("User ID mismatch or null user.");
            }
            var updatedUser = await _userService.UpdateUserAsync(id, registerDTO);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
