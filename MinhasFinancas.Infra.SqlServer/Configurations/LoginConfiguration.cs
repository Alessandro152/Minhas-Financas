using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades.Usuarios;

namespace MinhasFinancas.Infra.SqlServer.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<UsuarioLogin>
    {
        public void Configure(EntityTypeBuilder<UsuarioLogin> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Senha)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.UsuarioId)
                   .IsRequired();

            builder.ToTable("movfin_login");
        }
    }
}
