using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        ICrudRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity, IAggregateRoot;
        Task SaveChangesAsync();
    }
}
