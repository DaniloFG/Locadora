using Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Locadora.InfraData.EntitiesConfig
{
    public class RentConfig : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.DateWithdrawal)
                //.HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(l => l.DateDelivery)
                .IsRequired();

            builder.Property(l => l.DateDevolution)
                .IsRequired();

            builder.HasOne<Film>(l => l.Film)
                .WithMany(l => l.Rent)
                .HasForeignKey(l => l.FilmId);

            builder.HasOne<Client>(l => l.Client)
                .WithMany(l => l.Rent)
                .HasForeignKey(l => l.ClientId);
        }
    }
}
