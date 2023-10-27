using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using WebApiParser.Domain.SeedWork;
using Microsoft.Extensions.Options;
using WebApiParser.ReferenceParser.Options;

namespace WebApiParser.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailOptions> _options;

        public EmailService(IOptions<EmailOptions> options)
        {
            _options = options;
        }

        public void SendEmail(string to, string subject, string body)
        {
            using (SmtpClient smtpClient = new SmtpClient(_options.Value.SmtpServer))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_options.Value.Email, _options.Value.Password);
                smtpClient.EnableSsl = true;

                MailMessage message = new MailMessage(_options.Value.Email, to)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                smtpClient.Send(message);
            }
        }
    }
}
