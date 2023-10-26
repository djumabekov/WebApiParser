using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities;
using WebApiParser.ReferenceParser.DTOs;

namespace WebApiParser.ReferenceParser.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserModel>()
                .ForMember(x => x.Mail,
                    opt =>
                        opt.MapFrom(item => item.Mail));
            CreateMap<AuthModel, User>()
                .ForMember(x => x.Mail,
                    opt =>
                        opt.MapFrom(item => item.Mail))
                .ForMember(x => x.Password,
                    opt =>
                        opt.MapFrom(item => item.Password));
            CreateMap<RegistrationModel, User>()
                .ForMember(x => x.Mail,
                    opt =>
                        opt.MapFrom(item => item.Mail))
                .ForMember(x => x.Password,
                    opt =>
                        opt.MapFrom(item => item.Password));

        }
    }

}
