using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities;
using WebApiParser.Domain.Entities.References;
using WebApiParser.Domain.IRepositories;
using WebApiParser.Domain.IRepositories.References;
using WebApiParser.Domain.SeedWork;
using WebApiParser.Infrastructure.Repositories;
using WebApiParser.Infrastructure.Repositories.References;

namespace WebApiParser.Infrastructure
{
    public static class DiExtensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration config)
        {

            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(config)
            //    .CreateLogger();

            services.AddAutoMapper(typeof(ContractMapping).Assembly);
            services.AddAutoMapper(typeof(RefContractTypeMapping).Assembly);
            services.AddAutoMapper(typeof(RefContractStatusMapping).Assembly);
            services.AddScoped<AuthorizationReferencesMessageHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Repositories

            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<ICrudRepository<ContractEntity>, ContractRepository>();

            services.AddScoped<IRefContractTypeRepository, RefContractTypeRepository>();
            services.AddScoped<ICrudRepository<RefContractTypeEntity>, RefContractTypeRepository>();

            services.AddScoped<IRefContractStatusRepository, RefContractStatusRepository>();
            services.AddScoped<ICrudRepository<RefContractStatusEntity>, RefContractStatusRepository>();

            #endregion

            #region APIs

            services.AddRefitClient<IReferencesApi>().ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            })
                .ConfigureHttpClient(c => {
                    c.BaseAddress = new Uri(config["ReferencesApi:ApiEndpoint"] ?? string.Empty);
                    c.Timeout = TimeSpan.FromMinutes(30);
                }).AddHttpMessageHandler<AuthorizationReferencesMessageHandler>();

            #endregion

            #region Handlers

            services.AddTransient<ExtractContractHandler>();
            services.AddTransient<ExtractRefContractStatusHandler>();
            services.AddTransient<ExtractRefContractTypeHandler>();
            //services.AddTransient<PlansValidationHandler<PlanEntity>>();

            #endregion

            #region Services

            services.AddScoped<ReferencesManagerService>();



            #endregion

            return services;
        }

    }
}
