using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades.Financas;
using MinhasFinancas.Domain.Entidades.Usuarios;
using System.Reflection;

namespace MinhasFinancas.Infra.Data
{
    public abstract class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UsuarioLogin> Login { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MovimentoFinanceiro> MovimentoFinanceiro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
