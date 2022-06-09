using Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.InfraData.EntitiesConfig
{
    public class FilmConfig : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(f => f.Stock)
                .HasPrecision(6)
                .IsRequired();
        }
    }
}
