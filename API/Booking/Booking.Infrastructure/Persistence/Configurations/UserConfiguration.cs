using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Booking.Domain.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table name (Identity by default uses AspNetUsers)
        builder.ToTable("Users");

        // Key already inherited from IdentityUser (string Id)

        // Properties
        builder.Property(u => u.FullName)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(u => u.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        // Relationships
        builder.HasMany(u => u.Trips)
               .WithOne(t => t.Owner)
               .HasForeignKey(t => t.OwnerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Reservations)
               .WithOne(r => r.ReservedByUser)
               .HasForeignKey(r => r.ReservedByUserId)
               .OnDelete(DeleteBehavior.Restrict);

        // optional: seeding if you want
        // builder.HasData(UserSeed.Data);
    }
}
