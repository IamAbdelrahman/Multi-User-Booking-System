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
    public class TripAvailabilityConfiguration: IEntityTypeConfiguration<TripAvailability>
    {
        public void Configure(EntityTypeBuilder<TripAvailability> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.StartDate).
                IsRequired()
                .HasColumnType("datetime2(3)");


            builder.Property(x => x.EndDate)
            .IsRequired()
            .HasColumnType("datetime2(3)");

            builder.Property(x => x.IsAvailable)
                    .HasDefaultValue(true);

            builder.Property(x => x.TripId)
                .IsRequired();

            builder.HasOne(x => x.Trip)
                .WithMany(x => x.TripAvailabilities)
                .HasForeignKey(x => x.TripId);

            builder.HasData(TripAvailabilitySeed.Data);
        }
    }
}
