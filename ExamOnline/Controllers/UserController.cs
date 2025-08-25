using ExamOnline.Exceptions;
using ExamOnline.Interfaces.IUser;
using ExceptionHandleDemo.Exceptions;
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
                throw new NotFoundException($"User {id} not found");
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
        public async Task<IActionResult> UpdateUser(int id, [FromBody] RegisterDTO registerDTO)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, registerDTO);
            if (updatedUser == null)
            {
                throw new NotFoundException($"User {id} not found");
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
                throw new NotFoundException($"User {id} not found");
            }
            return NoContent();
        }
    }
}
