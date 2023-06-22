using FluentResults;
using MediatR;
using MinhasFinancas.Application.AppServices;
using MinhasFinancas.Application.Builders;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.Services;
using MinhasFinancas.CrossCutting.Bus;
using MinhasFinancas.Domain.Cliente.Handlers;
using MinhasFinancas.Domain.Commands.Usuarios;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Handlers.Financas;
using MinhasFinancas.Domain.Interface.Adapters;
using MinhasFinancas.Domain.Interface.Repositories;
using MinhasFinancas.Infra.Adapter;
using MinhasFinancas.Infra.Repositories;
using MinhasFinancas.Infra.Service;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjector
    { 
        public static IServiceCollection Injector(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            //Application
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IFinancasAppService, FinancasAppService>();
            services.AddTransient<ITokenBuilder, TokenBuilder>();
            services.AddTransient<ITokenAppService, TokenAppService>();

            //Domain
            services.AddTransient<IBusHandler, BusHandler>();
            services.AddTransient<IRequestHandler<NewUsuarioCommand, Result<Entidade>>, UsuarioHandler>();
            services.AddTransient<IRequestHandler<UpdateUsuarioCommand, Result<bool>>, UsuarioHandler>();
            services.AddTransient<IRequestHandler<NewMovimentoFinanceiroCommand, Result<Entidade>>, MovimentoFinanceiroHandler>();
            services.AddTransient<IRequestHandler<UpdateMovimentoFinanceiroCommand, Result<Entidade>>, MovimentoFinanceiroHandler>();

            //Infra
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioQueryRepository, UsuarioQueryRepository>();
            services.AddTransient<IMovimentoFinanceiroRepository, MovimentoFinanceiroRepository>();
            services.AddTransient<IFinancasQueryRepository, FinancasQueryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryAdapter, UsuarioRepositoryAdapter>();

            return services;
        }
    }
}
