using Application.Dtos;
using Application.Interfaces.IEmail;
using Application.Interfaces.Otp;
using Domain.Entities;
using ExamOnline.Exceptions;
using ExamOnline.Interfaces.IToken;
using Microsoft.AspNetCore.Identity;
using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OtpService : IOtpService
    {
        private static readonly Dictionary<string, (string Otp, DateTime Expiry)> _otpStorage = new();
        private readonly IEmailSenderService _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public OtpService(IEmailSenderService emailSender,
                          UserManager<ApplicationUser> userManager,
                          ITokenService tokenService)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task GenerateAndSendOtpAsync(ApplicationUser user)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            var expiry = DateTime.UtcNow.AddMinutes(1);
            _otpStorage[user.Id] = (otp, expiry);

            await _emailSender.SendEmailAsync(user.Email, "OTP Code", $"Mã OTP của bạn là: {otp}");
        }

        public string GenerateOtp(string userId)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            var expiry = DateTime.UtcNow.AddMinutes(1);

            _otpStorage[userId] = (otp, expiry);

            return otp;
        }

        public async Task<string> VerifyOtpAsync(OtpDto otpDto)
        {
            var user = await _userManager.FindByEmailAsync(otpDto.Email);
            if (user == null)
                throw new UnauthorizedException("Email not found");

            if (!_otpStorage.ContainsKey(user.Id))
                throw new UnauthorizedException("OTP not found");

            var (storedOtp, expiry) = _otpStorage[user.Id];

            if (DateTime.UtcNow > expiry)
            {
                _otpStorage.Remove(user.Id);
                throw new UnauthorizedException("OTP expired");
            }

            if (storedOtp != otpDto.Otp)
                throw new UnauthorizedException("Invalid OTP");

            _otpStorage.Remove(user.Id); // xoá sau khi dùng

            var token = await _tokenService.CreateToken(user);
            return token;
        }
    }
}
