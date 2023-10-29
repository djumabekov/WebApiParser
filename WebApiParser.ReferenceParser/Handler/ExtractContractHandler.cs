using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities;
using WebApiParser.Domain.SeedWork;
using WebApiParser.ReferenceParser.API;
using WebApiParser.ReferenceParser.DTOs;

namespace WebApiParser.ReferenceParser.Handler
{
    public class ExtractContractHandler : BaseHandler<ContractEntity, ContractModel>
    {
        private readonly IReferencesApi _referencesApi;
        private static int _counter = 0;

        public ExtractContractHandler(IReferencesApi referencesApi, IMapper mapper,
            IUnitOfWork unitOfWork) : base(referencesApi, unitOfWork, mapper)
        {
            _referencesApi = referencesApi;
        }

        protected override async Task<ApiResult<ContractModel>> ExtractDataFromApi(int after)
        {
            if (_counter < 20)
            {
                _counter++;
                return await _referencesApi.GetContract();
            }
            return null;
        }

    }
}
