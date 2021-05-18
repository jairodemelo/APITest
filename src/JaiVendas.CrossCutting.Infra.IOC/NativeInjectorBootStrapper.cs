using AutoMapper;
using JaiVendas.Application.AutoMapper;
using JaiVendas.Application.Interfaces;
using JaiVendas.Application.Services;
using JaiVendas.CrossCutting.Infra.Bus;
using JaiVendas.CrossCutting.Infra.Data.Context;
using JaiVendas.CrossCutting.Infra.Data.Repository;
using JaiVendas.CrossCutting.Infra.Data.UOW;
using JaiVendas.Domain.Interfaces;
using JaiVendas.Domain.Interfaces.Bus;
using JaiVendas.Domain.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JaiVendas.CrossCutting.Infra.IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("JaiVendas.Domain");
            var autoMapperConfig = AutoMapperConfig.RegisterMappings();

            return services

            //Bus
            .AddScoped<IMediatorHandler, InMemoryBus>()
            .AddMediatR(assembly)

            //Application
            .AddScoped<ICustomerAppService, CustomerAppService>()

            //Repository
            .AddScoped<ICustomerRepository, CustomerRepository>()

            //Data
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<JaiVendasDataContext>()
            
            //AutoMapper
            .AddSingleton<IMapper>(autoMapperConfig.CreateMapper());
        }
    }
}
