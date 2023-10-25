using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiParser.Infrastructure.Services
{
    public class ReferencesManagerService
    {
        private ExtractContractHandler _contractHandler;
        private ExtractRefContractTypeHandler _contractTypeHandler;
        private ExtractRefContractStatusHandler _contractStatusHandler;
        //private ContractsValidationHandler<ContractEntity> _contractsValidationHandler;

        public ReferencesManagerService(
            ExtractContractHandler contractHandler,
            ExtractRefContractTypeHandler contractTypeHandler,
            ExtractRefContractStatusHandler contractStatusHandler
            //ContractsValidationHandler contractsValidationHandler
            )
        {
            _contractHandler = contractHandler;
            _contractTypeHandler = contractTypeHandler;
            _contractStatusHandler = contractStatusHandler;
            //_contractsValidationHandler = contractsValidationHandler;
        }


        public async Task ExtractAllReferences()
        {
            _contractTypeHandler.SetNext(_contractStatusHandler);
            _contractStatusHandler.SetNext(_contractHandler);
            await _contractTypeHandler.Handle(new { });
        }
    }
}
