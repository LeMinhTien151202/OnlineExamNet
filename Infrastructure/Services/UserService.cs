using Application.Dtos;
using Application.Interfaces.IEmail;
using Application.Interfaces.Otp;
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
        private static Dictionary<string, string> _otpStorage = new(); // userId - otp
        private readonly IEmailSenderService _emailSender;
        private readonly IOtpService _otpService;
        public UserService(IMapper mapper, ExamOnlineContext context
            , ITokenService tokenService, IUnitOfWork unitOfWork, 
            IUserRepository userRepository, IConfiguration config,
            IEmailSenderService emailSender, IOtpService otpService)
        {
            _context = context;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _config = config;
            _emailSender = emailSender;
            _otpService = otpService;
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

            var token = await _tokenService.CreateToken(user);

            return token;
        }

        public async Task<string?> LoginEmailAsync(LoginEmailDTO dto)
        {
            var user = await _userRepository.FindByEmailAsync(dto.Email!);
            if (user == null)
            {
                throw new UnauthorizedException("Email or password not match");
            }

            var isPasswordValid = await _userRepository.CheckPasswordAsync(user, dto.Password!);
            if (!isPasswordValid)
            {
                throw new UnauthorizedException("Email or password not match");
            }
            // Sinh OTP bằng service riêng
            var otp = _otpService.GenerateOtp(user.Id);

            try
            {
                await _emailSender.SendEmailAsync(user.Email, "Your OTP Code", $"Your OTP is: {otp}");
            }
            catch (Exception)
            {
                throw new Exception("Failed to send OTP email. Please try again later.");
            }

            return "OTP sent to your email. Please verify.";
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
    }
}
