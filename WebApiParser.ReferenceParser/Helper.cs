using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiParser.ReferenceParser
{
    public static class Helper
    {
        public static int GetSearchAfter(string searchAfterText)
        {
            return int.Parse(Regex.Matches(searchAfterText, @"\d{1,}").Last().Value);
        }
    }
}
