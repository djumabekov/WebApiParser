using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.Domain.SeedWork
{
    public class ReferenceEntity : Entity
    {
        public Localizable Name { get; set; }
        public string Code { get; set; }
    }
}
