using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.SeedWork;
using WebApiParser.Infrastructure.Services;

namespace WebApiParser.Infrastructure.Handler
{

    public class EmailJob
    {
        private readonly IEmailService _emailService;
        private readonly UserService _userService; 


        public EmailJob(IEmailService emailService, UserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        public void SendEmailJob(string subject, string message)
        {
            var userEmails = _userService.GetUserEmails().Result; 
            foreach (var email in userEmails)
            {
                _emailService.SendEmail(email, subject, message);
            }
        }
    }


}
