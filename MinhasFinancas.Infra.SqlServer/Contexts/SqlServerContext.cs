using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.Infra.Extensions;
using System.Reflection;

namespace MinhasFinancas.Infra.SqlServer.Contexts
{
    public class SqlServerContext : DataContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer(Secret.ConnectionString.Decrypt());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
