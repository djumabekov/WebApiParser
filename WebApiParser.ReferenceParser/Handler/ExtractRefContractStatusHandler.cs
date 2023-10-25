using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities.References;
using WebApiParser.Domain.SeedWork;
using WebApiParser.ReferenceParser.API;
using WebApiParser.ReferenceParser.DTOs;

namespace WebApiParser.ReferenceParser.Handler
{
    public class ExtractRefContractStatusHandler : BaseHandler<RefContractStatusEntity, RefContractStatusModel>
    {
        private readonly IReferencesApi _referencesApi;
        public ExtractRefContractStatusHandler(IReferencesApi referencesApi, IMapper mapper,
            IUnitOfWork unitOfWork) : base(referencesApi, unitOfWork, mapper)
        {
            _referencesApi = referencesApi;
        }

        protected override async Task<ApiResult<RefContractStatusModel>> ExtractDataFromApi(int after)
        {
            return await _referencesApi.GetRefContractStatus();
        }
    }
}