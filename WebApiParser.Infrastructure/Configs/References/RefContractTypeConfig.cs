using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Configs.Common;
using WebApiParser.Domain.Entities.References;

namespace WebApiParser.Infrastructure.Configs.References
{
    public class RefContractTypeConfig : ReferenceEntityConfig<RefContractTypeEntity>
    {
        protected override void Config(EntityTypeBuilder<RefContractTypeEntity> builder)
        {
            builder.ToTable("RefContractType", schema: "public");
        }
    }
}
