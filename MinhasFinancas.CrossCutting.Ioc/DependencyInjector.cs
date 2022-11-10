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
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.Adapter;
using MinhasFinancas.Infra.Interface;
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
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IMinhasFinancasAppService, MinhasFinancasAppService>();
            services.AddScoped<ITokenBuilder, TokenBuilder>();
            services.AddScoped<ITokenAppService, TokenAppService>();

            //Domain
            services.AddScoped<IBusHandler, BusHandler>();
            services.AddScoped<IRequestHandler<NewUsuarioCommand, Result<Entidade>>, UsuarioHandler>();
            services.AddScoped<IRequestHandler<UpdateUsuarioCommand, Result<bool>>, UsuarioHandler>();
            services.AddScoped<IRequestHandler<NewMovimentoFinanceiroCommand, Result<Entidade>>, MovimentoFinanceiroHandler>();
            services.AddScoped<IRequestHandler<UpdateMovimentoFinanceiroCommand, Result<Entidade>>, MovimentoFinanceiroHandler>();

            //Infra
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioQueryRepository, UsuarioQueryRepository>();
            services.AddScoped<IMovimentoFinanceiroRepository, MovimentoFinanceiroRepository>();
            services.AddScoped<IMovimentoFinanceiroQueryRepository, MovimentoFinanceiroQueryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryAdapter, UsuarioRepositoryAdapter>();

            return services;
        }
    }
}
