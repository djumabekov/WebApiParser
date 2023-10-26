using AutoMapper;
using Refit;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.SeedWork;
using WebApiParser.ReferenceParser.API;

namespace WebApiParser.ReferenceParser.Handler
{
    public class BaseHandler<TDomain, TDto> : AbstractHandler
    where TDomain : Entity, IAggregateRoot
    where TDto : class
    {
        protected readonly IReferencesApi _referencesApi;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private List<TDomain> _list = new();

        protected BaseHandler(IReferencesApi referencesApi, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _referencesApi = referencesApi;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<object> Handle(object request)
        {
            var data = await GetDataRecursive(0);
            if (data)
            {
                try
                {
                    var domainRepository = _unitOfWork.GetRepository<TDomain>();
                    await domainRepository.AddRangeAsync(_list.ToArray());
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception exception)
                {
                    Log.Debug(exception.Message);
                    Log.Information(exception.Message);
                    Log.Warning(exception.Message);
                    Log.Error(exception.Message);
                    return base.Handle(request);
                }
            }
            return base.Handle(request);
        }

        protected virtual async Task<ApiResult<TDto>> ExtractDataFromApi(int after) => await Task.FromResult(new ApiResult<TDto>());

        protected virtual async Task<bool> GetDataRecursive(int after)
        {

            try
            {
                var result = await ExtractDataFromApi(after);

                if (result == null)
                {
                    return true;

                }

                var items = _mapper.Map<List<TDto>, List<TDomain>>
                    (result.Items.ToList());
                _list.AddRange(items);
                if (string.IsNullOrEmpty(result.Next_Page))
                {
                    return true;
                }
                return await GetDataRecursive(Helper.GetSearchAfter(result.Next_Page));

            }
            catch (ApiException exception)
            {
                var errors = await exception.GetContentAsAsync<Dictionary<string, string>>();
                if (errors?.Values != null)
                {
                    var message = string.Join("; ", errors.Values);
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine(exception.ToString());
                }
                Log.Debug(exception.Message);
                Log.Information(exception.Message);
                Log.Warning(exception.Message);
                Log.Error(exception.Message);
                return false;
            }
        }
    }
}
