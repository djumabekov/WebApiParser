using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities;
using WebApiParser.ReferenceParser.DTOs;

namespace WebApiParser.ReferenceParser.Mapping
{
    public class ContractMapping : Profile
    {
        public ContractMapping() {
            CreateMap<ContractModel, ContractEntity>()
                .ForMember(x => x.ContractId, opt => opt.MapFrom(item => item.id))
                .ForMember(x => x.SystemId, opt => opt.MapFrom(item => item.system_id))
                //.ForMember(x => x.ContractNumber, opt => opt.MapFrom(item => item.contract_number != null ? long.Parse(item.contract_number) : (long?)null))
                .ForMember(x => x.ContractNumberSys, opt => opt.MapFrom(item => item.contract_number_sys))
                .ForMember(x => x.TrdBuyId, opt => opt.MapFrom(item => item.trd_buy_id))
                .ForMember(x => x.TrdBuyNumberAnno, opt => opt.MapFrom(item => item.trd_buy_number_anno))
                .ForMember(x => x.RefContractTypeId, opt => opt.MapFrom(item => item.ref_contract_type_id))
                .ForMember(x => x.RefContractStatusId, opt => opt.MapFrom(item => item.ref_contract_status_id))
                //.ForMember(x => x.CrDate, opt => opt.MapFrom(item => item.crdate))
                .ForMember(x => x.CrDate, opt => opt.MapFrom(item => DateTimeOffset.ParseExact(item.crdate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToUniversalTime()))

                .ForMember(x => x.ContractSum, opt => opt.MapFrom(item => item.contract_sum))
                .ForMember(x => x.ContractSumWnds, opt => opt.MapFrom(item => item.contract_sum_wnds))
                .ForMember(x => x.SupplierId, opt => opt.MapFrom(item => item.supplier_id))
                .ForMember(x => x.SupplierBin, opt => opt.MapFrom(item => item.supplier_biin))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(item => item.customer_id))
                .ForMember(x => x.CustomerBin, opt => opt.MapFrom(item => item.customer_bin))
                //.ForMember(x => x.IndexDate, opt => opt.MapFrom(item => item.index_date))
                .ForMember(x => x.IndexDate, opt => opt.MapFrom(item => DateTimeOffset.ParseExact(item.index_date, "yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture).ToUniversalTime()))
                ; 
            ;


        }
    }
}
