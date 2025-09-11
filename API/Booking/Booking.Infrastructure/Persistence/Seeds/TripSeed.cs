using Azure;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Seeds
{
    static class TripSeed
    {
        public static List<Trip> Data => new()
                        {
                            new Trip
                            {
                                Id = "new-id-for-trip-paris",
                                Name = "Discover Paris: The City of Lights",
                                CityName = "Paris",
                                Price = 1250.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34",
                                Content = "<p>Explore the romantic streets of Paris, from the iconic Eiffel Tower to the historic Louvre Museum. This trip includes a Seine River cruise and a visit to Notre-Dame.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 9, 10),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-venice",
                                Name = "Venice Canal Tour",
                                CityName = "Venice",
                                Price = 950.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1511527661048-7fe73d8e441f",
                                Content = "<p>Glide through the enchanting canals of Venice on a traditional gondola. Discover hidden gems and enjoy the unique charm of this floating city.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 8, 20),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-tokyo",
                                Name = "Tokyo: Modern Meets Tradition",
                                CityName = "Tokyo",
                                Price = 2100.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1542051841857-5f90071e79859",
                                Content = "<p>Experience the vibrant energy of Tokyo. Visit ancient temples in Asakusa, explore the bustling Shibuya Crossing, and indulge in world-class Japanese cuisine.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 7, 15),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-rome",
                                Name = "Rome: Ancient Wonders",
                                CityName = "Rome",
                                Price = 1350.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1552832230-c0197dd311b5",
                                Content = "<p>Step back in time as you explore the Colosseum, Roman Forum, and Pantheon. Our expert guides will bring the history of the Roman Empire to life.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 6, 5),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-grand-canyon",
                                Name = "Grand Canyon Adventure",
                                CityName = "Las Vegas",
                                Price = 650.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1508739773434-c26b3d09e071",
                                Content = "<p>Take a day trip from Las Vegas to the majestic Grand Canyon. This tour includes transportation, lunch, and spectacular photo opportunities.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 5, 22),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-himalayan-trek",
                                Name = "Himalayan Trek",
                                CityName = "Kathmandu",
                                Price = 3500.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1554119102-285cf5c5a5bd",
                                Content = "<p>Embark on an unforgettable trekking journey through the breathtaking Himalayas. Witness stunning mountain vistas and remote village life.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 4, 18),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-cairo",
                                Name = "Cairo & Pyramids",
                                CityName = "Cairo",
                                Price = 1800.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1539768979805-0d4b4e891edf",
                                Content = "<p>Uncover the mysteries of ancient Egypt. This trip includes a visit to the Giza pyramids, the Sphinx, and the Egyptian Museum.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 3, 11),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-kyoto",
                                Name = "Kyoto Zen Gardens",
                                CityName = "Kyoto",
                                Price = 1900.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1493976040374-85c8e12f2c0e",
                                Content = "<p>Find tranquility in Kyoto. Visit serene Zen gardens, stunning temples, and traditional tea houses. A peaceful escape from the city.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 2, 25),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-machu-picchu",
                                Name = "Machu Picchu Explorer",
                                CityName = "Cusco",
                                Price = 2800.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1509219433878-6d6efcaab3b0",
                                Content = "<p>Hike the Inca Trail or take a scenic train ride to the magnificent lost city of Machu Picchu. An incredible journey through ancient Incan history.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2024, 1, 30),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-iceland",
                                Name = "Iceland Northern Lights",
                                CityName = "Reykjavik",
                                Price = 1600.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1515496281367-1a96cdab32bd",
                                Content = "<p>Chase the Aurora Borealis in Iceland. This tour also includes visits to geysers, waterfalls, and the famous Blue Lagoon.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 12, 12),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-kenya",
                                Name = "Safari in Kenya",
                                CityName = "Nairobi",
                                Price = 4500.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1509817923753-9e0551c691f9",
                                Content = "<p>Witness the Great Migration in the Maasai Mara. An unforgettable safari experience with up-close encounters with Africa's wildlife.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 11, 5),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-sydney",
                                Name = "Sydney Harbour Tour",
                                CityName = "Sydney",
                                Price = 850.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1506973035872-a4ec16b8e8d9",
                                Content = "<p>Sail across the iconic Sydney Harbour, with spectacular views of the Opera House and Harbour Bridge. A perfect way to see the city.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 10, 28),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-santorini",
                                Name = "Santorini Sunset Cruise",
                                CityName = "Santorini",
                                Price = 1500.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff",
                                Content = "<p>Experience the legendary sunset of Santorini from a luxury catamaran. Includes dinner and swimming stops in the Aegean Sea.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 9, 15),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-new-york",
                                Name = "New York City: The Big Apple",
                                CityName = "New York",
                                Price = 1750.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1496442226666-8d4d0e62f167",
                                Content = "<p>A whirlwind tour of NYC's highlights, including Times Square, Central Park, and the Statue of Liberty. A trip full of energy and excitement.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 8, 30),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-berlin",
                                Name = "Berlin History Tour",
                                CityName = "Berlin",
                                Price = 1050.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1467269204594-9661b64199da",
                                Content = "<p>Dive into the rich and complex history of Berlin. Visit the Brandenburg Gate, the Berlin Wall Memorial, and Museum Island.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 7, 21),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-dubai",
                                Name = "Dubai Desert Safari",
                                CityName = "Dubai",
                                Price = 700.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1512453979798-5ea266f8880c",
                                Content = "<p>Experience the thrill of a desert safari with dune bashing, camel riding, and a traditional Arabian dinner under the stars.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 6, 14),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-rio",
                                Name = "Rio de Janeiro Carnival",
                                CityName = "Rio de Janeiro",
                                Price = 2500.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1483729558449-99ef09a8c325",
                                Content = "<p>Join the world's most famous party! Experience the vibrant parades, samba music, and stunning beaches of Rio during Carnival.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 5, 5),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-prague",
                                Name = "Prague Old Town",
                                CityName = "Prague",
                                Price = 1100.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1541849541-09ce6311e891",
                                Content = "<p>Stroll through the cobblestone streets of Prague's historic Old Town. See the Astronomical Clock, Charles Bridge, and Prague Castle.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 4, 19),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-amsterdam",
                                Name = "Amsterdam Canal Cruise",
                                CityName = "Amsterdam",
                                Price = 900.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1534351590667-b8c8c3566fe0",
                                Content = "<p>Discover Amsterdam's unique charm from its iconic canals. This cruise offers a new perspective on the city's historic architecture.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 3, 22),
                                IsActive = true
                            },
                            new Trip
                            {
                                Id = "new-id-for-trip-bavarian-alps",
                                Name = "Bavarian Alps Hiking",
                                CityName = "Munich",
                                Price = 1400.00m,
                                ImageUrl = "https://images.unsplash.com/photo-1519643381401-22c77e60520e",
                                Content = "<p>Hike through the stunning scenery of the Bavarian Alps. Visit fairytale castles and enjoy the fresh mountain air in southern Germany.</p>",
                                OwnerId = "3dacdb51-fee9-4479-904c-cafe7dca22a7",
                                Created = new DateTime(2023, 2, 10),
                                IsActive = true
                            }
                        };
    }
}