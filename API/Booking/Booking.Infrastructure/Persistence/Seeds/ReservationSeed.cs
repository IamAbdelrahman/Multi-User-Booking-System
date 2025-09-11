using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Seeds
{
    static class ReservationSeed
    {
        public static List<Reservation> Data => new()
                    {
                        new Reservation
                        {
                            Id = "b1a6c8a2-9f4e-4f0d-8b4b-1a2d3e4f5a60",
                            ReservedByUserId = "user-1111-2222-3333-4444aaaa",
                            CustomerName = "Alice Johnson",
                            TripId = "trip-aaa1-222b-333c-444d5555",
                            ReservationDate = new DateTime(2023, 09, 15, 10, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 09, 15, 10, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2023, 10, 01, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2023, 10, 05, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Prefers quiet accommodation room and late check-in for the trip.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "c2b7d9b3-0a5f-4e1e-9c5c-2b3e4f6a7b81",
                            ReservedByUserId = "user-2222-3333-4444-5555bbbb",
                            CustomerName = "Bob Smith",
                            TripId = "trip-bbb2-333c-444d-555e6666",
                            ReservationDate = new DateTime(2024, 01, 05, 09, 30, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 01, 05, 09, 30, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 02, 10, 14, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 02, 15, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Requests airport pickup for trip arrival.",
                            Status = "Pending"
                        },

                        new Reservation
                        {
                            Id = "d3c8eac4-1b6f-5f2f-0d6d-3c4f5e8f9c92",
                            ReservedByUserId = "user-3333-4444-5555-6666cccc",
                            CustomerName = "Carla Reyes",
                            TripId = "trip-ccc3-444d-555e-666f7777",
                            ReservationDate = new DateTime(2024, 05, 20, 12, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 05, 20, 12, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 06, 01, 16, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 06, 07, 10, 0, 0, DateTimeKind.Utc),
                            Notes = null,
                            Status = "Cancelled"
                        },

                        // Additional seeded reservations to reach nearly 20 entries
                        new Reservation
                        {
                            Id = "e4d9f0a5-2c7a-4b3b-8f7e-4d5e6f7a8b13",
                            ReservedByUserId = "user-1111-2222-3333-4444aaaa",
                            CustomerName = "Daniel Kim",
                            TripId = "trip-aaa1-222b-333c-444d5555",
                            ReservationDate = new DateTime(2023, 11, 02, 08, 15, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 11, 02, 08, 15, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2023, 12, 20, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2023, 12, 25, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Allergic to feather bedding during accommodation.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "f5e0a1b6-3d8b-4c4c-9g8f-5e6f7a8b9c24".Replace("g","f"), // kept valid hex by replacing
                            ReservedByUserId = "user-4444-5555-6666-7777dddd",
                            CustomerName = "Evelyn Turner",
                            TripId = "trip-ddd4-555e-666f-777g8888".Replace("g","a"),
                            ReservationDate = new DateTime(2024, 02, 14, 18, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 02, 14, 18, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 03, 10, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 03, 12, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Vegetarian meals requested for trip dining.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "a6f1b2c7-4e9c-4d5d-0a9b-6f7a8b9c0d35",
                            ReservedByUserId = "user-2222-3333-4444-5555bbbb",
                            CustomerName = "Frank Liu",
                            TripId = "trip-bbb2-333c-444d-555e6666",
                            ReservationDate = new DateTime(2024, 03, 01, 07, 45, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 03, 01, 07, 45, 0, DateTimeKind.Utc),
                            UpdatedAt = new DateTime(2024, 03, 02, 10, 0, 0, DateTimeKind.Utc),
                            CheckIn = new DateTime(2024, 04, 05, 14, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 04, 09, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Requests extra towels at accommodation.",
                            Status = "Pending"
                        },

                        new Reservation
                        {
                            Id = "b7g2c3d8-5f0d-4e6e-1b0c-7g8h9i0j1k46".Replace("g","a").Replace("h","b").Replace("i","c").Replace("j","d").Replace("k","e"),
                            ReservedByUserId = "user-5555-6666-7777-8888eeee",
                            CustomerName = "Gabriela Santos",
                            TripId = "trip-eee5-666f-777g-888h9999".Replace("g","a").Replace("h","b"),
                            ReservationDate = new DateTime(2024, 04, 10, 13, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 04, 10, 13, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 05, 01, 16, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 05, 04, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Anniversary package requested for trip accommodations.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "c8h3d4e9-6g1e-5f7f-2c1d-8h9i0j1k2l57".Replace("g","b").Replace("h","a").Replace("i","b").Replace("j","c").Replace("k","d").Replace("l","e"),
                            ReservedByUserId = "user-3333-4444-5555-6666cccc",
                            CustomerName = "Hassan Ali",
                            TripId = "trip-ccc3-444d-555e-666f7777",
                            ReservationDate = new DateTime(2024, 06, 02, 11, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 06, 02, 11, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 07, 15, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 07, 20, 11, 0, 0, DateTimeKind.Utc),
                            Notes = null,
                            Status = "Cancelled"
                        },

                        new Reservation
                        {
                            Id = "d9i4e5f0-7h2f-6g8g-3d2e-9i0j1k2l3m68".Replace("g","c").Replace("h","a").Replace("i","b").Replace("j","c").Replace("k","d").Replace("l","e").Replace("m","f"),
                            ReservedByUserId = "user-7777-8888-9999-0000ffff",
                            CustomerName = "Ivy Chen",
                            TripId = "trip-fff6-777g-888h-999i0000".Replace("g","a").Replace("h","b").Replace("i","c"),
                            ReservationDate = new DateTime(2024, 07, 21, 09, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 07, 21, 09, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 08, 05, 16, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 08, 12, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Needs a crib at accommodation during the trip.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "e0j5f6g1-8i3g-7h9h-4e3f-0j1k2l3m4n79".Replace("g","d").Replace("h","e").Replace("i","b").Replace("j","c").Replace("k","d").Replace("l","e").Replace("m","f").Replace("n","a"),
                            ReservedByUserId = "user-4444-5555-6666-7777dddd",
                            CustomerName = "Jack O'Neill",
                            TripId = "trip-ggg7-888h-999i-000j1111".Replace("g","a").Replace("h","b").Replace("i","c").Replace("j","d"),
                            ReservationDate = new DateTime(2024, 08, 01, 14, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 08, 01, 14, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = new DateTime(2024, 08, 05, 10, 0, 0, DateTimeKind.Utc),
                            CheckIn = new DateTime(2024, 09, 10, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 09, 14, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Late arrival expected for trip check-in.",
                            Status = "Pending"
                        },

                        new Reservation
                        {
                            Id = "f1k6g7h2-9j4h-8i0i-5f4g-1k2l3m4n5o80".Replace("g","e").Replace("h","f").Replace("i","a").Replace("j","b").Replace("k","c").Replace("l","d").Replace("m","e").Replace("n","f").Replace("o","1"),
                            ReservedByUserId = "user-5555-6666-7777-8888eeee",
                            CustomerName = "Kara Novak",
                            TripId = "trip-hhh8-999i-000j-111k2222".Replace("h","a").Replace("i","b").Replace("j","c").Replace("k","d"),
                            ReservationDate = new DateTime(2024, 09, 12, 10, 30, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 09, 12, 10, 30, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 10, 01, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 10, 03, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Allergic to nuts; please note for trip meals.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "a2l7h8i3-0k5i-9j1j-6g5h-2l3m4n5o6p91".Replace("j","a").Replace("k","b").Replace("l","c").Replace("m","d").Replace("n","e").Replace("o","f").Replace("p","0"),
                            ReservedByUserId = "user-1111-2222-3333-4444aaaa",
                            CustomerName = "Liam O'Connor",
                            TripId = "trip-aaa1-222b-333c-444d5555",
                            ReservationDate = new DateTime(2024, 10, 05, 12, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 10, 05, 12, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 11, 20, 16, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 11, 25, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Includes celebration package during the trip.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "b3m8i9j4-1l6j-0k2k-7h6i-3m4n5o6p7q02".Replace("k","b").Replace("l","a").Replace("m","c").Replace("n","d").Replace("o","e").Replace("p","f").Replace("q","1"),
                            ReservedByUserId = "user-2222-3333-4444-5555bbbb",
                            CustomerName = "Maya Patel",
                            TripId = "trip-bbb2-333c-444d-555e6666",
                            ReservationDate = new DateTime(2024, 11, 11, 09, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 11, 11, 09, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2024, 12, 24, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2024, 12, 31, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Holiday trip booking.",
                            Status = "Pending"
                        },

                        new Reservation
                        {
                            Id = "c4n9j0k5-2m7k-1l3l-8i7j-4n5o6p7q8r13".Replace("l","b").Replace("m","a").Replace("n","c").Replace("o","d").Replace("p","e").Replace("q","f").Replace("r","1"),
                            ReservedByUserId = "user-3333-4444-5555-6666cccc",
                            CustomerName = "Noah Williams",
                            TripId = "trip-ccc3-444d-555e-666f7777",
                            ReservationDate = new DateTime(2024, 12, 01, 10, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 12, 01, 10, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2025, 01, 10, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2025, 01, 15, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Booked with \"Ring in the New Year\" trip package.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "d5o0k1l6-3n8l-2m4m-9j8k-5o6p7q8r9s24".Replace("m","c").Replace("n","a").Replace("o","b").Replace("p","d").Replace("q","e").Replace("r","f").Replace("s","1"),
                            ReservedByUserId = "user-7777-8888-9999-0000ffff",
                            CustomerName = "Olivia Brown",
                            TripId = "trip-fff6-777g-888h-999i0000".Replace("g","a").Replace("h","b").Replace("i","c"),
                            ReservationDate = new DateTime(2025, 01, 15, 11, 30, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2025, 01, 15, 11, 30, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2025, 02, 01, 16, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2025, 02, 07, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Prefers window seat for flights related to the trip.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "e6p1l2m7-4o9m-3n5n-0k9l-6p7q8r9s0t35".Replace("n","d").Replace("o","a").Replace("p","b").Replace("q","c").Replace("r","d").Replace("s","e").Replace("t","1"),
                            ReservedByUserId = "user-4444-5555-6666-7777dddd",
                            CustomerName = "Peter Novak",
                            TripId = "trip-ddd4-555e-666f-777a8888",
                            ReservationDate = new DateTime(2025, 03, 03, 12, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2025, 03, 03, 12, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2025, 04, 10, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2025, 04, 14, 11, 0, 0, DateTimeKind.Utc),
                            Notes = null,
                            Status = "Pending"
                        },

                        new Reservation
                        {
                            Id = "f7q2m3n8-5p0n-4o6o-1l0m-7q8r9s0t1u46".Replace("o","e").Replace("p","a").Replace("q","b").Replace("r","c").Replace("s","d").Replace("t","e").Replace("u","1"),
                            ReservedByUserId = "user-5555-6666-7777-8888eeee",
                            CustomerName = "Quinn Harper",
                            TripId = "trip-eee5-666f-777a-888b9999",
                            ReservationDate = new DateTime(2025, 04, 20, 09, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2025, 04, 20, 09, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = new DateTime(2025, 04, 22, 10, 0, 0, DateTimeKind.Utc),
                            CheckIn = new DateTime(2025, 05, 05, 16, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2025, 05, 09, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Pescatarian diet requested for trip meals.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "a8r3n4o9-6q1o-5p7p-2m1n-8r9s0t1u2v57".Replace("p","f").Replace("q","a").Replace("r","b").Replace("s","c").Replace("t","d").Replace("u","e").Replace("v","1"),
                            ReservedByUserId = "user-1111-2222-3333-4444aaaa",
                            CustomerName = "Rita Gomez",
                            TripId = "trip-aaa1-222b-333c-444d5555",
                            ReservationDate = new DateTime(2025, 06, 12, 13, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2025, 06, 12, 13, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2025, 07, 18, 15, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2025, 07, 22, 11, 0, 0, DateTimeKind.Utc),
                            Notes = "Requires accessible accommodation during the trip.",
                            Status = "Confirmed"
                        },

                        new Reservation
                        {
                            Id = "b9s4o5p0-7r2p-6q8q-3n2o-9s0t1u2v3w68".Replace("q","b").Replace("r","a").Replace("s","c").Replace("t","d").Replace("u","e").Replace("v","f").Replace("w","1"),
                            ReservedByUserId = "user-2222-3333-4444-5555bbbb",
                            CustomerName = "Samuel Reed",
                            TripId = "trip-bbb2-333c-444d-555e6666",
                            ReservationDate = new DateTime(2025, 08, 01, 10, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2025, 08, 01, 10, 0, 0, DateTimeKind.Utc),
                            UpdatedAt = null,
                            CheckIn = new DateTime(2025, 08, 15, 16, 0, 0, DateTimeKind.Utc),
                            CheckOut = new DateTime(2025, 08, 20, 11, 0, 0, DateTimeKind.Utc),
                            Notes = null,
                            Status = "Completed"
                        },
                    };
    }
}
