using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinhasFinancas.Application.AppServices;
using MinhasFinancas.Application.Builders;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Application.Services;
using MinhasFinancas.Domain.Cliente.Commands;
using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Financas.Commands;
using MinhasFinancas.Domain.Interface;
using MinhasFinancas.Infra.CrossCutting;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.Interface;
using MinhasFinancas.Infra.Repositories;
using MinhasFinancas.Infra.Service;
using System.Reflection;
using System.Text;

namespace MinhasFinancas.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Mediatr
            services.AddMediatR(typeof(Assembly).GetTypeInfo().Assembly);

            //Register
            InitializeContainer(services);

            //Contexto do banco de dados
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("database"));

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Minhas Finanças Api - Swagger",
                    Version = "v1"
                });
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "bearerAuth"
                              }
                          },
                         new string[] {}
                    }
                });
            });

            //Autenticacao Jwt
            var key = Encoding.ASCII.GetBytes(Setting.Secret);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }

        private void InitializeContainer(IServiceCollection services)
        {
            //Application
            services.AddScoped<IUsuarioAppServiceHandler, UsuarioAppServiceHandler>();
            services.AddScoped<IMinhasFinancasAppServiceHandler, MinhasFinancasAppServiceHandler>();
            services.AddScoped<ITokenBuilder, TokenBuilder>();
            services.AddScoped<ITokenService, TokenService>();

            //Domain
            services.AddScoped<IBusHandler, BusHandler>();
            services.AddMediatR(typeof(NewUsuarioCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(NewLoginCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(NewMovimentoFinanceiroCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateMovimentoFinanceiroCommand).GetTypeInfo().Assembly);

            //Infra
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMovimentoFinanceiroRepository, MovimentoFinanceiroRepository>();
            services.AddScoped<IMovimentoFinanceiroQueryHandler, MovimentoFinanceiroQueryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minhas Finanças Api - Swagger");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
