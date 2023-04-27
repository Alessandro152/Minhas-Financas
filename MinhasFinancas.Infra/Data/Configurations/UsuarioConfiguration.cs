using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {   
            builder.Property(p => p.Id)
                   .ValueGeneratedNever();

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Email)
                   .IsRequired();

            builder.HasOne(p => p.Login)
                   .WithOne()
                   .HasForeignKey<Login>(f => f.UsuarioId);
        }
    }
}
