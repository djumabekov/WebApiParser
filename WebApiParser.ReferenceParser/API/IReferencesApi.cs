using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.ReferenceParser.DTOs;

namespace WebApiParser.ReferenceParser.API
{
    public interface IReferencesApi
    {
        [Get("/contract?page=next&limit={limit}&search_after={after}")]
        public Task<ApiResult<ContractModel>> GetContract([AliasAs("after")] int after = 0, [AliasAs("limit")] int? limit = 2000);
        
        [Get("/refs/ref_contract_status?page=next&limit={limit}&search_after={after}")]
        public Task<ApiResult<RefContractStatusModel>> GetRefContractStatus([AliasAs("after")] int after = 0, [AliasAs("limit")] int? limit = 2000);
        
        [Get("/refs/ref_contract_type?page=next&limit={limit}&search_after={after}")]
        public Task<ApiResult<RefContractTypeModel>> GetRefContractType([AliasAs("after")] int after = 0, [AliasAs("limit")] int? limit = 2000);
    }
}
