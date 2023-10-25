using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.Domain.SeedWork
{
    public class Localizable
    {
        public string? Ru { get; set; }
        public string? Kk { get; set; }

        public Localizable()
        {
            Ru = "";
            Kk = "";
        }
        public Localizable(string? ru, string? kk)
        {
            Ru = ru;
            Kk = kk;
        }
    }
}
