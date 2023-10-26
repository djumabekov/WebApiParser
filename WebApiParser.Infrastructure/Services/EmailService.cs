using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace WebApiParser.Infrastructure.Services
{
    public class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.mail.ru"))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("jandil@mail.ru", "123");
                smtpClient.EnableSsl = true;

                MailMessage message = new MailMessage("jandil@mail.ru", to)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                smtpClient.Send(message);
            }
        }
    }

    

    public class EmailJob
    {
        public void SendEmailJob()
        {
            var emailService = new EmailService();
            emailService.SendEmail("jandil@mail.ru", "Subject", "Message body");
        }
    }


}
