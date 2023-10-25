using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.Domain.SeedWork
{
    public class Entity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public long SystemId { get; set; }
    }

    public class NamedEntity : Entity
    {
        public Localizable Name { get; set; }
    }
}
