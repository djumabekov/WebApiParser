using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Configs.Common;
using WebApiParser.Domain.Entities;

namespace WebApiParser.Domain.Configs
{
    public class ContractConfig : BaseEntityConfig<ContractEntity>
    {
        protected override void Config(EntityTypeBuilder<ContractEntity> builder)
        {
            builder.ToTable("Contracts", schema: "public");

            builder.HasOne(x => x.RefContractType).WithMany()
               .HasForeignKey(x => x.RefContractTypeId).HasPrincipalKey(x => x.SystemId)
               .IsRequired(true).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            builder.HasOne(x => x.RefContractStatus).WithMany()
                .HasForeignKey(x => x.RefContractStatusId).HasPrincipalKey(x => x.SystemId)
                .IsRequired(true).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
