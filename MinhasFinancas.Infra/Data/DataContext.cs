using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        public DbSet<Login> Login { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<MovimentoFinanceiro> Valores { get; set; }
    }
}
