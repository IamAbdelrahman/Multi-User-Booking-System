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
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Alice Johnson",
                    TripId = "new-id-for-trip-paris",
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
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Bob Smith",
                    TripId = "new-id-for-trip-venice",
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
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Carla Reyes",
                    TripId = "new-id-for-trip-tokyo",
                    ReservationDate = new DateTime(2024, 05, 20, 12, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2024, 05, 20, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = null,
                    CheckIn = new DateTime(2024, 06, 01, 16, 0, 0, DateTimeKind.Utc),
                    CheckOut = new DateTime(2024, 06, 07, 10, 0, 0, DateTimeKind.Utc),
                    Notes = null,
                    Status = "Cancelled"
                },
                new Reservation
                {
                    Id = "e4d9f0a5-2c7a-4b3b-8f7e-4d5e6f7a8b13",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Daniel Kim",
                    TripId = "new-id-for-trip-paris",
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
                    Id = "f5e0a1b6-3d8b-4c4c-9f8f-5e6f7a8b9c24",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Evelyn Turner",
                    TripId = "new-id-for-trip-rome",
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
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Frank Liu",
                    TripId = "new-id-for-trip-venice",
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
                    Id = "b7a2c3d8-5f0d-4e6e-1b0c-7a8b9c0d1e46",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Gabriela Santos",
                    TripId = "new-id-for-trip-grand-canyon",
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
                    Id = "c8a3d4e9-6b1e-5f7f-2c1d-8ab9cde57",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Hassan Ali",
                    TripId = "new-id-for-trip-tokyo",
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
                    Id = "d9b4e5f0-7a2f-6c8c-3d2e-9bcdef68",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Ivy Chen",
                    TripId = "new-id-for-trip-himalayan-trek",
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
                    Id = "e0c5f6d1-8b3d-7e9e-4e3f-0c1d2e3f4a79",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Jack O'Neill",
                    TripId = "new-id-for-trip-cairo",
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
                    Id = "f1c6d7e2-9b4f-8a0a-5f4e-1c2d3e4f5180",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Kara Novak",
                    TripId = "new-id-for-trip-kyoto",
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
                    Id = "a2c7e8f3-0b5a-9a1a-6d5e-2c3d4e5f6091",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Liam O'Connor",
                    TripId = "new-id-for-trip-paris",
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
                    Id = "b3c8a9d4-1a6a-0b2b-7c6d-3c4d5e6f7102",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Maya Patel",
                    TripId = "new-id-for-trip-venice",
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
                    Id = "c4c9d0e5-2a7b-1b3b-8d7e-4c5d6e7f8113",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Noah Williams",
                    TripId = "new-id-for-trip-tokyo",
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
                    Id = "d5b0c1d6-3a8b-2c4c-9d8e-5bcdef14",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Olivia Brown",
                    TripId = "new-id-for-trip-himalayan-trek",
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
                    Id = "e6b1c2d7-4a9c-3d5d-0a9b-6bcdef15",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Peter Novak",
                    TripId = "new-id-for-trip-rome",
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
                    Id = "f7b2c3d8-5a0d-4e6e-1b0c-7bcdef16",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Quinn Harper",
                    TripId = "new-id-for-trip-grand-canyon",
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
                    Id = "a8b3c4d9-6a1c-5f7f-2c1d-8bcde17",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Rita Gomez",
                    TripId = "new-id-for-trip-paris",
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
                    Id = "b9c4d5e0-7a2d-6b8b-3c2d-9cdef18",
                    ReservedByUserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    CustomerName = "Samuel Reed",
                    TripId = "new-id-for-trip-venice",
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