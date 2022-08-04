using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MinhasFinancas.Application.Adapter;
using MinhasFinancas.Application.AppServices;
using MinhasFinancas.Application.Builders;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.Services;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Cliente.Handlers;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Financas.Handlers;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Domain.Notifications;
using MinhasFinancas.Infra.CrossCutting;
using MinhasFinancas.Infra.Interface;
using MinhasFinancas.Infra.Repositories;
using MinhasFinancas.Infra.Service;

namespace MinhasFinancas.CrossCutting.Ioc
{
    public static class DependencyInjector
    { 
        public static void Injector(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IUsuarioAppService, UsuarioAppServiceHandler>();
            services.AddScoped<IMinhasFinancasAppService, MinhasFinancasAppServiceHandler>();
            services.AddScoped<ITokenBuilder, TokenBuilder>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IApplicationAdapter, ApplicationAdapter>();

            //Domain
            services.AddScoped<IBusHandler, BusHandler>();
            services.AddScoped<IDomainNotification, DomainNotifications>();
            services.AddScoped<IRequestHandler<NewUsuarioCommand, Result>, UsuarioHandler>();
            services.AddScoped<IRequestHandler<UpdateUsuarioCommand, Result>, UsuarioHandler>();
            services.AddScoped<IRequestHandler<NewMovimentoFinanceiroCommand, Result>, MovimentoFinanceiroHandler>();
            services.AddScoped<IRequestHandler<UpdateMovimentoFinanceiroCommand, Result>, MovimentoFinanceiroHandler>();

            //Infra
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioQueryRepository, UsuarioQueryRepository>();
            services.AddScoped<IMovimentoFinanceiroRepository, MovimentoFinanceiroRepository>();
            services.AddScoped<IMovimentoFinanceiroQueryRepository, MovimentoFinanceiroQueryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
