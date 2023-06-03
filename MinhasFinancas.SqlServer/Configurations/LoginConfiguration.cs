using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades;

namespace MinhasFinancas.Infra.SqlServer
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Senha)
                   .HasMaxLength(6)
                   .IsRequired();

            builder.Property(p => p.UsuarioId)
                   .IsRequired();

            builder.ToTable("movfin_login");
        }
    }
}
