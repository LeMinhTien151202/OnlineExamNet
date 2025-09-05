using ExamOnline.Exceptions;
using ExamOnline.Interfaces.IUser;
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
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserName(string name)
        {
            var user = await _userService.GetByNameAsync(name);
            if (user == null)
            {
                throw new NotFoundException($"User {name} not found");
            }
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO.PassWord != registerDTO.ReTypePassWord)
            {
                throw new BadRequestException("Password isn't equals.");
            }
            var createdUser = await _userService.RegisterAsync(registerDTO);
            return Ok(createdUser);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {

            var token = await _userService.LoginAsync(loginDTO);

            if (token == null)
                throw new UnauthorizedException("username or password not match");

            return Ok(new
            {
                Message = "Login successful.",
                Token = token
            });
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "user, teacher, admin")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] RegisterDTO registerDTO)
        {
            var updatedUser = await _userService.UpdateAsync(id, registerDTO);
            //if (updatedUser == null)
            //{
            //    throw new Exceptions.NotFoundException($"User {id} not found");
            //}
            if (!updatedUser.Succeeded)
                throw new BadRequestException("Failed to update user");
            return Ok(updatedUser);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result.Succeeded)
                throw new BadRequestException("Failed to delete user");

            return Ok("User deleted successfully");
        }
    }
}
