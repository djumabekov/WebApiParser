﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities.References;
using WebApiParser.Domain.IRepositories.References;

namespace WebApiParser.Infrastructure.Repositories.References
{
    internal class RefContractTypeRepository : BaseRepository<RefContractTypeEntity>, IRefContractTypeRepository
    {
        public RefContractTypeRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
