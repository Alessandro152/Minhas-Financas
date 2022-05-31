using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(p => p.Id)
                .ValueGeneratedNever();

            builder
                .HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.OwnsOne(v => v.Login, p =>
            {
                p.Property(p => p.Email)
                .IsRequired();

                p.Property(p => p.Password)
                .HasMaxLength(6)
                .IsRequired();
            });

            builder.HasOne<Login>();
        }
    }
}
