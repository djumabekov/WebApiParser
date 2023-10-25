using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.ReferenceParser.Options
{
    public class ReferenceApiOption
    {
        public string ApiEndpoint { get; set; }
        public string Token { get; set; }
        public string AuthorizationScheme { get; set; }
    }
}
