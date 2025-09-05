using Application.Dtos;
using Domain.Entities;
using ExamOnline.Dtos;
using ExamOnline.Exceptions;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Interfaces.IToken;
using ExamOnline.Interfaces.IUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExamOnline.Services
{
    public class UserService : IUserService
    {
        private readonly ExamOnlineContext _context;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        public UserService(IMapper mapper, ExamOnlineContext context
            , ITokenService tokenService, IUnitOfWork unitOfWork, 
            IUserRepository userRepository, IConfiguration config)
        {
            _context = context;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User không tồn tại" });

            return await _userRepository.DeleteAsync(user);
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var result = new List<UserDTO>();

            foreach (var user in users)
            {
                result.Add(await MapToDTOAsync(user));
            }

            return result;
        }

        public async Task<UserDTO?> GetByNameAsync(string username)
        {
            var user = await _userRepository.FindByNameAsync(username);
            if (user == null) return null;

            return await MapToDTOAsync(user);
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            var user = await _userRepository.FindByNameAsync(dto.UserName!);
            if (user == null) return null;

            var isPasswordValid = await _userRepository.CheckPasswordAsync(user, dto.PassWord!);
            if (!isPasswordValid) return null;

            var roles = await _userRepository.GetRolesAsync(user);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id)

        };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDTO dto)
        {
            var user = new ApplicationUser
            {
                FullName = dto.FullName,
                PhoneNumber = dto.Phone,
                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await _userRepository.CreateAsync(user, dto.PassWord!);
            if (result.Succeeded)
            {
                await _userRepository.AddToRoleAsync(user, "user");
            }
            return result;
        }

        public async Task<IdentityResult> UpdateAsync(string id, RegisterDTO dto)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User không tồn tại" });
            user.FullName = dto.FullName;
            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, dto.PassWord!);
            user.PhoneNumber = dto.Phone;

            return await _userRepository.UpdateAsync(user);
        }
        public async Task<UserDTO> MapToDTOAsync(ApplicationUser user)
        {
            var roles = await _userRepository.GetRolesAsync(user);

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Roles = roles
            };
        }


        //public async Task<string?> LoginAsync(LoginDTO loginDTO)
        //{
        //    var user = await _context.Users
        //    .Include(u => u.Role)
        //    .FirstOrDefaultAsync(u => u.UserName!.Equals(loginDTO.UserName, StringComparison.Ordinal));

        //    if (user == null)
        //       return null;

        //    // So sánh mật khẩu
        //    if (!BCrypt.Net.BCrypt.Verify(loginDTO.PassWord, user.PassWord))
        //        return null;

        //    return _tokenService.CreateToken(user);
        //}

        //public async Task<string?> RegisterAsync(RegisterDTO registerDTO)
        //{
        //    var role = await _unitOfWork.Roles.GetByIdAsync(registerDTO.RoleId);
        //    if (role == null)
        //    {
        //        throw new BadRequestException("Role does not exist.");
        //    }
        //    if (await _context.Users.AnyAsync(u => u.UserName == registerDTO.UserName))
        //    {
        //        throw new BadRequestException("User name already exists.");
        //    }
        //    var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.PassWord);
        //    var user = new User
        //    {
        //        UserName = registerDTO.UserName,
        //        Phone = registerDTO.Phone,
        //        PassWord = passwordHash,
        //        Email = registerDTO.Email,
        //        RoleId = registerDTO.RoleId
        //    };
        //    var createdUser = await _unitOfWork.Users.CreateAsync(user);
        //    await _context.SaveChangesAsync();
        //    return "User created successfully.";
        //}

        //public async Task<User?> UpdateUserAsync(int id, RegisterDTO registerDTO)
        //{
        //    var role = await _unitOfWork.Roles.GetByIdAsync(registerDTO.RoleId);
        //    if (role == null)
        //    {
        //        throw new BadRequestException($"Role with ID {registerDTO.RoleId} does not exist.");
        //    }
        //    var existingUser = await _unitOfWork.Users.GetByIdAsync(id);
        //    if (existingUser == null)
        //    {
        //        return null; // User not found
        //    }
        //    var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.PassWord);

        //    existingUser.UserId = id;
        //    existingUser.UserName = registerDTO.UserName;
        //    existingUser.Phone = registerDTO.Phone;
        //    existingUser.PassWord = passwordHash;
        //    existingUser.Email = registerDTO.Email;
        //    existingUser.RoleId = registerDTO.RoleId;

        //    var updatedUser = await _unitOfWork.Users.UpdateAsync(existingUser);
        //    return updatedUser;
        //}
    }
}
