using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.SqlServer;

namespace GestaoOrcamento.Infra.Oracle
{
    public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
    {
        public SqlServerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();

            builder.UseSqlServer("Server=tcp:aircooledserver.database.windows.net,1433;Initial Catalog=aircooled;Persist Security Info=False;User ID=useradmin;Password=Virago@535;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new SqlServerDbContext(builder.Options);
        }
    }
}
