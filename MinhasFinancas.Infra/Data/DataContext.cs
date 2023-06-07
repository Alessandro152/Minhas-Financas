using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades;
using System.Reflection;

namespace MinhasFinancas.Infra.Data
{
    public abstract class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MovimentoFinanceiro> MovimentoFinanceiro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
