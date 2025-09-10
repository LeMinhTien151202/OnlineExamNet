using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Otp
{
    public interface IOtpService
    {
        string GenerateOtp(string userId);
        //Task GenerateAndSendOtpAsync(ApplicationUser user);
        Task<string> VerifyOtpAsync(OtpDto otpDto);
    }
}
