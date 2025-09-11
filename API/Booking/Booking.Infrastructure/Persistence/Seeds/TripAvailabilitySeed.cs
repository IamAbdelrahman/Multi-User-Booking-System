using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Domain.Entities;
namespace Booking.Infrastructure.Persistence.Seeds
{
    public static class TripAvailabilitySeed
    {
        public static List<TripAvailability> Data = new List<TripAvailability>
        {
            new TripAvailability
            {
                Id = 1,
                TripId = "new-id-for-trip-paris",
                StartDate = new DateTime(2024, 07, 01),
                EndDate = new DateTime(2024, 07, 10),
                IsAvailable = true
            },
            new TripAvailability
            {
                Id = 2,
                TripId = "new-id-for-trip-venice",
                StartDate = new DateTime(2024, 08, 01),
                EndDate = new DateTime(2024, 08, 15),
                IsAvailable = true
            },
            new TripAvailability
            {
                Id = 3,
                TripId = "new-id-for-trip-tokyo",
                StartDate = new DateTime(2024, 07, 05),
                EndDate = new DateTime(2024, 07, 20),
                IsAvailable = true
            },
            new TripAvailability
            {
                Id = 4,
                TripId = "new-id-for-trip-rome",
                StartDate = new DateTime(2024, 09, 01),
                EndDate = new DateTime(2024, 09, 10),
                IsAvailable = true
            },
            new TripAvailability
            {
                Id = 5,
                TripId = "new-id-for-trip-grand-canyon",
                StartDate = new DateTime(2024, 06, 15),
                EndDate = new DateTime(2024, 06, 25),
                IsAvailable = true
            },
            new TripAvailability
            {
                Id = 6,
                TripId = "new-id-for-trip-himalayan-trek",
                StartDate = new DateTime(2024, 10, 01),
                EndDate = new DateTime(2024, 10, 15),
                IsAvailable = true
            }
        };
    }
}