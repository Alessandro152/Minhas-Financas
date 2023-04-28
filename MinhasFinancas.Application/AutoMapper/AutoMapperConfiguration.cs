using MinhasFinancas.Application.AutoMapper.Usuarios;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(config => 
            {
                config.AddProfile<UsuarioToDto>();
            });
        }
    }
}
