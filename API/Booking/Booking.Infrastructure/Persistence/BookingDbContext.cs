using Booking.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence
{
    public class BookingDbContext: IdentityDbContext<User>
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TripAvailability> TripAvailabilities { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
