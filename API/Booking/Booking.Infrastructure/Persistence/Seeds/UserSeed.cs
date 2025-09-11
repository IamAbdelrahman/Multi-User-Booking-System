using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Seeds
{
    public class UserSeed
    {
        public static List<User> Data => new()
        {
            new User
            {
                Id = "2dacdb51-fee9-4479-904c-cafe7dca22a6",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEO/q6OSHKyNTnPIucWSWuAmTqfZHsqAMA+fnMfFPz28zoy4gwyv9Qy1QTjaAOCnJYg==",
                SecurityStamp = "2O776OTQMPGHNUKGKGVD7EK56EWEHWJ4",
                ConcurrencyStamp = "2bc5ed7c-f23c-41b2-8f24-6cde1379cf70",
                PhoneNumberConfirmed = false,
            },
            new User
            {
                Id = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                UserName = "host",
                NormalizedUserName = "HOST",
                Email = "host@email.com",
                NormalizedEmail = "HOST@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEKPhsE1ZH2ywRVcOxNIhAIIfbvEEEUx9a0cKblC7AG3bUp7kBN57YBS6h4eiSpcieg==",
                SecurityStamp = "HOSTSTAMP",
                ConcurrencyStamp = "3bc5ed7c-f23c-41b2-8f24-6cde1379cf70",
                PhoneNumberConfirmed = false,
            },
            new User
            {
                Id = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                UserName = "customer",
                NormalizedUserName = "CUSTOMER",
                Email = "customer@email.com",
                NormalizedEmail = "CUSTOMER@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEMWTZVZgAJ/EsUyRjvSvhzLikb2SaCnhIAP7KuZmp8g7Gofn24rv/MdjHEUgNyB68w==",
                SecurityStamp = "CUSTOMERTAMP",
                ConcurrencyStamp = "4bc5ed7c-f23c-41b2-8f24-6cde1379cf70",
                PhoneNumberConfirmed = false,
            }
        };
    }
}
