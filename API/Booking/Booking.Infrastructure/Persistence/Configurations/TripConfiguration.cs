using Booking.Domain.Entities;
using Booking.Infrastructure.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.Property(r => r.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(t => t.Name).HasMaxLength(200).IsRequired();

            builder.Property(t => t.CityName).HasMaxLength(100).IsRequired();

            builder.Property(t => t.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(t => t.ImageUrl).HasMaxLength(2000);

            builder.Property(t => t.Content).HasColumnType("nvarchar(max)");

            // Timestamp configurations
            builder.Property(x => x.Created)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(t => t.IsActive).IsRequired().HasDefaultValue(true);

            builder.HasOne(t => t.Owner)
                   .WithMany(u => u.Trips)
                   .HasForeignKey(t => t.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            // Indexes for better query performance
            builder.HasIndex(t => t.Name);
            builder.HasIndex(t => t.CityName);
            builder.HasIndex(t => t.Price);
            builder.HasIndex(t => t.IsActive);
            builder.HasIndex(t => t.OwnerId);

            // Seed data
            builder.HasData(TripSeed.Data);
        }
    }
}
