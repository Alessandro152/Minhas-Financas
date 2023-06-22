using Microsoft.Extensions.Configuration;

namespace MinhasFinancas.Infra.SqlServer
{
    public class BancoDadosConfig
    {
        public BancoDadosConfig(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Aircooled");
        }

        public static string ConnectionString { get; set; }
    }
}
