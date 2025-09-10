using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IEmail
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
        Task<string?> VerifyOtpEmailAsync(OtpDto otpDto);
    }
}
