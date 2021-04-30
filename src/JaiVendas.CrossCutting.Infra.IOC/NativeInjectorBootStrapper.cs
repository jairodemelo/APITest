using JaiVendas.Application.Interfaces;
using JaiVendas.Application.Services;
using JaiVendas.CrossCutting.Infra.Data.Context;
using JaiVendas.CrossCutting.Infra.Data.Repository;
using JaiVendas.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JaiVendas.CrossCutting.Infra.IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services

            //Application
            .AddScoped<ICustomerAppService, CustomerAppService>()

            //Repository
            .AddScoped<ICustomerRepository, CustomerRepository>()

            //Data
            .AddScoped<JaiVendasDataContext>();
        }
    }
}
