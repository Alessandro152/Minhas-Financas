using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedNever();

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Email)
                   .IsRequired();

            builder.Property(p => p.Password)
                   .HasMaxLength(6)
                   .IsRequired();
        }
    }
}
