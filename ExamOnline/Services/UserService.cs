using ExamOnline.Dtos;
using ExamOnline.Interfaces.IRole;
using ExamOnline.Interfaces.IToken;
using ExamOnline.Interfaces.IUser;
using ExceptionHandleDemo.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Services
{
    public class UserService : IUserService
    {
        private readonly ExamOnlineContext _context;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IMapper mapper, ExamOnlineContext context
            , ITokenService tokenService, IUnitOfWork unitOfWork)
        {
            _context = context;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _unitOfWork.Users.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<string?> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserName!.Equals(loginDTO.UserName, StringComparison.Ordinal));

            if (user == null)
               return null;

            // So sánh mật khẩu
            if (!BCrypt.Net.BCrypt.Verify(loginDTO.PassWord, user.PassWord))
                return null;

            return _tokenService.CreateToken(user);
        }

        public async Task<string?> RegisterAsync(RegisterDTO registerDTO)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(registerDTO.RoleId);
            if (role == null)
            {
                throw new BadRequestException("Role does not exist.");
            }
            if (await _context.Users.AnyAsync(u => u.UserName == registerDTO.UserName))
            {
                throw new BadRequestException("User name already exists.");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.PassWord);
            var user = new User
            {
                UserName = registerDTO.UserName,
                Phone = registerDTO.Phone,
                PassWord = passwordHash,
                Email = registerDTO.Email,
                RoleId = registerDTO.RoleId
            };
            var createdUser = await _unitOfWork.Users.CreateAsync(user);
            await _context.SaveChangesAsync();
            return "User created successfully.";
        }

        public async Task<User?> UpdateUserAsync(int id, RegisterDTO registerDTO)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(registerDTO.RoleId);
            if (role == null)
            {
                throw new BadRequestException($"Role with ID {registerDTO.RoleId} does not exist.");
            }
            var existingUser = await _unitOfWork.Users.GetByIdAsync(id);
            if (existingUser == null)
            {
                return null; // User not found
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.PassWord);

            existingUser.UserId = id;
            existingUser.UserName = registerDTO.UserName;
            existingUser.Phone = registerDTO.Phone;
            existingUser.PassWord = passwordHash;
            existingUser.Email = registerDTO.Email;
            existingUser.RoleId = registerDTO.RoleId;
            
            var updatedUser = await _unitOfWork.Users.UpdateAsync(existingUser);
            return updatedUser;
        }
    }
}
