using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities;
using WebApiParser.Domain.SeedWork;

namespace WebApiParser.Domain.IRepositories
{
    public interface IContractRepository : ICrudRepository<ContractEntity>
    {
    }
}
