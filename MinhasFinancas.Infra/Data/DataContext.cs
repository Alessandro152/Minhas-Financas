using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades;

namespace MinhasFinancas.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<MovimentoFinanceiro> Valores { get; set; }
    }
}
