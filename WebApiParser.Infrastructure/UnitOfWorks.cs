using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.SeedWork;

namespace WebApiParser.Infrastructure
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceScope _serviceScope;
        private readonly AppDbContext _context;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceScope = serviceProvider.CreateScope();
            _context = _serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        }

        public ICrudRepository<TDomain> GetRepository<TDomain>()
            where TDomain : Entity, IAggregateRoot
        {
            return (_serviceScope.ServiceProvider.GetRequiredService(typeof(ICrudRepository<TDomain>)) as ICrudRepository<TDomain>)!;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
