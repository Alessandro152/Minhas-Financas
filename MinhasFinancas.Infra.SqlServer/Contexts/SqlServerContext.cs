using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Infra.Data;
using System.Reflection;

namespace MinhasFinancas.Infra.SqlServer.Contexts
{
    public class SqlServerContext : DataContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
