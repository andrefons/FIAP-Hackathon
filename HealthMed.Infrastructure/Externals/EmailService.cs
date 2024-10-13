using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Application.Interfaces;
using HealthMed.Shared;

namespace HealthMed.Infrastructure.Externals
{
    public class EmailService(IOptions<EmailSettings> options) : IEmailService
    {
        private readonly EmailSettings _emailSettings = options.Value;

        public async Task<Result> SendAsync(string email, string subject, string content)
        {
            try
            {
                using var smtpClient = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password)
                };

                var mailMessage = new MailMessage
                {
                    SubjectEncoding = System.Text.Encoding.UTF8,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    IsBodyHtml = true,
                    From = new(_emailSettings.From),
                    Subject = subject,
                    Body = content
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);

                return new Result();
            }
            catch (Exception ex)
            {
                return new Result().AddErrorMessage(ex.Message);
            }            
        }
    }
}
