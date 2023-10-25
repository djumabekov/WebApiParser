using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities;
using WebApiParser.Domain.Entities.References;
using WebApiParser.ReferenceParser.DTOs;

namespace WebApiParser.ReferenceParser.Mapping
{
    public class RefContractTypeMapping : Profile
    {
        public RefContractTypeMapping()
        {
            CreateMap<RefContractTypeModel, RefContractTypeEntity>()
                .ForMember(x => x.Id, opt => opt.MapFrom(item => item.id))
                .ForPath(x => x.Name.Ru, opt => opt.MapFrom(item => item.name_ru))
                .ForPath(x => x.Name.Kk, opt => opt.MapFrom(item => item.name_kz));
        }
    }
}
