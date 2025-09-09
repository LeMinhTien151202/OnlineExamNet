using Application.Dtos;
using Application.Interfaces.IEmail;
using Domain.Entities;
using ExamOnline.Interfaces.IToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _config;
        private static Dictionary<string, string> _otpStorage = new(); // userId - otp
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        public EmailSenderService(IConfiguration config,
            UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _config = config;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            using var client = new SmtpClient(_config["Smtp:Host"], int.Parse(_config["Smtp:Port"]))
            {
                Credentials = new NetworkCredential(_config["Smtp:User"], _config["Smtp:Pass"]),
                EnableSsl = true
            };

            var mailMessage = new MailMessage(_config["Smtp:User"], toEmail, subject, message);
            await client.SendMailAsync(mailMessage);
        }

        public async Task<string?> VerifyOtpEmailAsync(OtpDto otpDto)
        {
            var user = await _userManager.FindByEmailAsync(otpDto.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Email not found");
            }

            if (!_otpStorage.ContainsKey(user.Id) || _otpStorage[user.Id] != otpDto.Otp)
            {
                throw new UnauthorizedAccessException("Invalid OTP");
            }
            _otpStorage.Remove(user.Id); // Xóa OTP sau khi dùng

            var token = await _tokenService.CreateToken(user);

            return token;
        }
    }
}
