using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.ReferenceParser.API
{
    public class ApiResult<TDomain> where TDomain : class
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public string? Next_Page { get; set; }
        public List<TDomain> Items { get; set; }
    }
}
