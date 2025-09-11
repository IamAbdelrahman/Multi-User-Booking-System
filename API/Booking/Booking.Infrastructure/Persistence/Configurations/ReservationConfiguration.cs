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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.CustomerName).HasMaxLength(200).IsRequired();
            builder.Property(r => r.ReservationDate).IsRequired();
            builder.Property(r => r.CreatedAt).IsRequired();
            builder.Property(r => r.Notes).HasMaxLength(1000);

            // Relationship: Reservation -> User (ReservedBy)
            builder.HasOne(r => r.ReservedByUser)
                   .WithMany(u => u.Reservations)
                   .HasForeignKey(r => r.ReservedByUserId)
                   // choose Restrict to prevent accidental cascade delete of reservations when user is removed
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            // Relationship: Reservation -> Trip
            builder.HasOne(r => r.Trip)
                   .WithMany(t => t.Reservations)
                   .HasForeignKey(r => r.TripId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            // Indexes for better query performance
            builder.HasIndex(r => r.ReservedByUserId);
            builder.HasIndex(r => r.TripId);
            builder.HasIndex(r => r.CheckIn);
            builder.HasIndex(r => r.CheckOut);
            builder.HasIndex(r => r.Status);

            // Seed data
            builder.HasData(ReservationSeed.Data);
        }
    }
}
