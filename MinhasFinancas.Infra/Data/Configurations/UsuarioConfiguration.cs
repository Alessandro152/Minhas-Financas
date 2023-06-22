using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades.Usuarios;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(p => p.Id);

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Email)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
