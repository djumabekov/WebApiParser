using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Configs.Common;
using WebApiParser.Domain.Entities;

namespace WebApiParser.Infrastructure.Configs
{
    public class UserConfig : BaseEntityConfig<User>
    {
        protected override void Config(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", schema: "public");
        }
    }

}
