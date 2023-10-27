using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.ReferenceParser.Options
{
    public class EmailOptions
    {
        public string SmtpServer { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
