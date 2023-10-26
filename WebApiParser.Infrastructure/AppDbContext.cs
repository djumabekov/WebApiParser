using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Configs;
using WebApiParser.Domain.Entities;
using WebApiParser.Domain.Entities.References;
using WebApiParser.Infrastructure.Configs;
using WebApiParser.Infrastructure.Configs.References;

namespace WebApiParser.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContractEntity> Contracts { get; set; }
        public DbSet<RefContractTypeEntity> RefContractType { get; set; }
        public DbSet<RefContractStatusEntity> RefContractStatus { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContractConfig());
            modelBuilder.ApplyConfiguration(new RefContractTypeConfig());
            modelBuilder.ApplyConfiguration(new RefContractStatusConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
