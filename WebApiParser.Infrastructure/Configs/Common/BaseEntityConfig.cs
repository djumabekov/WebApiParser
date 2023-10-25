using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.SeedWork;

namespace WebApiParser.Domain.Configs.Common
{
    public abstract class BaseEntityConfig<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : Entity
    {
        protected abstract void Config(EntityTypeBuilder<TDomain> builder);

        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            builder.HasKey(x => x.Id);
            Config(builder);
        }
    }

}
