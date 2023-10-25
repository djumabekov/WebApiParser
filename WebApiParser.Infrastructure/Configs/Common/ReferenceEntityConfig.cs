using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.SeedWork;

namespace WebApiParser.Domain.Configs.Common
{
    public abstract class ReferenceEntityConfig<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : ReferenceEntity
    {
        protected abstract void Config(EntityTypeBuilder<TDomain> builder);

        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(a => a.Name, name =>
            {
                name.Property(p => p.Ru);
                name.Property(p => p.Kk);
            });
            Config(builder);
        }
    }
}
