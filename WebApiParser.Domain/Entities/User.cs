using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.SeedWork;

namespace WebApiParser.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now.ToUniversalTime();
        public DateTimeOffset ModificationDate { get; set; } = DateTimeOffset.Now.ToUniversalTime();
        public DateTimeOffset LastAuthDate { get; set; }
    }
}
