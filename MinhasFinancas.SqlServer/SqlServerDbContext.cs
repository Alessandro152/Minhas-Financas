using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Infra.Data;
using System.Reflection;

namespace MinhasFinancas.Infra.SqlServer
{
    public class SqlServerDbContext : DataContext
    {
        public SqlServerDbContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
