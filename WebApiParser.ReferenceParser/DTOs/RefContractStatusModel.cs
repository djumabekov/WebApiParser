using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.ReferenceParser.DTOs
{
    public class RefContractStatusModel
    {
        public int id { get; set; }
        public string? name_ru { get; set; }
        public string? name_kz { get; set; }
        public string? code { get; set; }
    }
}
