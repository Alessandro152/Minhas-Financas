using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades.Usuarios;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<UsuarioLogin>
    {
        public void Configure(EntityTypeBuilder<UsuarioLogin> builder)
        {
            builder.Property(p => p.Id);

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Senha)
                   .HasMaxLength(6)
                   .IsRequired();

            builder.Property(p => p.UsuarioId)
                   .IsRequired();

            builder.HasOne(p => p.Usuario)
                   .WithOne(p => p.Login)
                   .HasForeignKey<UsuarioLogin>(p => p.UsuarioId);
        }
    }
}
