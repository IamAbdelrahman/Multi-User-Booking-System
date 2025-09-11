using Azure;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Seeds
{
    public class TripSeed
    {
        public static List<Trip> Data() => new()
                {

                    new Trip
                    {
                        Id = "d3a1f3e2-1c4b-4a2f-9f45-0a1b2c3d4e01",
                        Name = "Discover Paris: The City of Lights",
                        CityName = "Paris",
                        Price = 1250.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34",
                        Content = "<p>Explore the romantic streets of Paris, from the iconic Eiffel Tower to the historic Louvre Museum. This trip includes a Seine River cruise and a visit to Notre-Dame.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 9, 10),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "a4b2c3d4-5e6f-47a1-8b9c-0d1e2f3a4b02",
                        Name = "Venice Canal Tour",
                        CityName = "Venice",
                        Price = 950.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1511527661048-7fe73d8e441f",
                        Content = "<p>Glide through the enchanting canals of Venice on a traditional gondola. Discover hidden gems and enjoy the unique charm of this floating city.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 8, 20),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "c5d6e7f8-9a01-4b2c-8d7e-1f2a3b4c5d03",
                        Name = "Tokyo: Modern Meets Tradition",
                        CityName = "Tokyo",
                        Price = 2100.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1542051841857-5f90071e79859",
                        Content = "<p>Experience the vibrant energy of Tokyo. Visit ancient temples in Asakusa, explore the bustling Shibuya Crossing, and indulge in world-class Japanese cuisine.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 7, 15),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "f1e2d3c4-b5a6-4c3d-9a8b-2c3d4e5f6a04",
                        Name = "Rome: Ancient Wonders",
                        CityName = "Rome",
                        Price = 1350.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1552832230-c0197dd311b5",
                        Content = "<p>Step back in time as you explore the Colosseum, Roman Forum, and Pantheon. Our expert guides will bring the history of the Roman Empire to life.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 6, 5),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "21f4e7d8-3a9b-4c6d-8e7f-3b2a1c4d5e05",
                        Name = "Grand Canyon Adventure",
                        CityName = "Las Vegas",
                        Price = 650.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1508739773434-c26b3d09e071",
                        Content = "<p>Take a day trip from Las Vegas to the majestic Grand Canyon. This tour includes transportation, lunch, and spectacular photo opportunities.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 5, 22),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "6f5e4d3c-2b1a-4f3e-9d8c-4e3f2a1b6c06",
                        Name = "Himalayan Trek",
                        CityName = "Kathmandu",
                        Price = 3500.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1554119102-285cf5c5a5bd",
                        Content = "<p>Embark on an unforgettable trekking journey through the breathtaking Himalayas. Witness stunning mountain vistas and remote village life.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 4, 18),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "7a8b9c0d-1e2f-4a5b-8c7d-5f6e7d8c9b07",
                        Name = "Cairo & Pyramids",
                        CityName = "Cairo",
                        Price = 1800.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1539768979805-0d4b4e891edf",
                        Content = "<p>Uncover the mysteries of ancient Egypt. This trip includes a visit to the Giza pyramids, the Sphinx, and the Egyptian Museum.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 3, 11),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "8b7c6d5e-4f3a-4b2c-9a8b-6c5d4e3f2a08",
                        Name = "Kyoto Zen Gardens",
                        CityName = "Kyoto",
                        Price = 1900.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1493976040374-85c8e12f2c0e",
                        Content = "<p>Find tranquility in Kyoto. Visit serene Zen gardens, stunning temples, and traditional tea houses. A peaceful escape from the city.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 2, 25),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "9c8d7e6f-5a4b-4c3d-8e7f-7a6b5c4d3e09",
                        Name = "Machu Picchu Explorer",
                        CityName = "Cusco",
                        Price = 2800.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1509219433878-6d6efcaab3b0",
                        Content = "<p>Hike the Inca Trail or take a scenic train ride to the magnificent lost city of Machu Picchu. An incredible journey through ancient Incan history.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2024, 1, 30),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "a0b1c2d3-6e5f-4a2b-9c8d-8b7c6d5e4f10",
                        Name = "Iceland Northern Lights",
                        CityName = "Reykjavik",
                        Price = 1600.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1515496281367-1a96cdab32bd",
                        Content = "<p>Chase the Aurora Borealis in Iceland. This tour also includes visits to geysers, waterfalls, and the famous Blue Lagoon.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 12, 12),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "b1c2d3e4-7f6a-4b3c-8d9e-9c8b7a6d5e11",
                        Name = "Safari in Kenya",
                        CityName = "Nairobi",
                        Price = 4500.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1509817923753-9e0551c691f9",
                        Content = "<p>Witness the Great Migration in the Maasai Mara. An unforgettable safari experience with up-close encounters with Africa's wildlife.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 11, 5),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "c2d3e4f5-8a7b-4c5d-9e0f-0d9c8b7a6e12",
                        Name = "Sydney Harbour Tour",
                        CityName = "Sydney",
                        Price = 850.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1506973035872-a4ec16b8e8d9",
                        Content = "<p>Sail across the iconic Sydney Harbour, with spectacular views of the Opera House and Harbour Bridge. A perfect way to see the city.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 10, 28),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "d3e4f5a6-9b8c-4d6e-0f1a-1e0d9c8b7a13",
                        Name = "Santorini Sunset Cruise",
                        CityName = "Santorini",
                        Price = 1500.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff",
                        Content = "<p>Experience the legendary sunset of Santorini from a luxury catamaran. Includes dinner and swimming stops in the Aegean Sea.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 9, 15),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "e4f5a6b7-0c9d-4e7f-1a2b-2f1e0d9c8b14",
                        Name = "New York City: The Big Apple",
                        CityName = "New York",
                        Price = 1750.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1496442226666-8d4d0e62f167",
                        Content = "<p>A whirlwind tour of NYC's highlights, including Times Square, Central Park, and the Statue of Liberty. A trip full of energy and excitement.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 8, 30),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "f5a6b7c8-1d0e-4f8a-2b3c-3a2f1e0d9c15",
                        Name = "Berlin History Tour",
                        CityName = "Berlin",
                        Price = 1050.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1467269204594-9661b64199da",
                        Content = "<p>Dive into the rich and complex history of Berlin. Visit the Brandenburg Gate, the Berlin Wall Memorial, and Museum Island.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 7, 21),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "a6b7c8d9-2e1f-4a9b-3c4d-4b3a2f1e0d16",
                        Name = "Dubai Desert Safari",
                        CityName = "Dubai",
                        Price = 700.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1512453979798-5ea266f8880c",
                        Content = "<p>Experience the thrill of a desert safari with dune bashing, camel riding, and a traditional Arabian dinner under the stars.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 6, 14),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "b7c8d9e0-3f2a-4bad-4d5e-5c4b3a2f1e17",
                        Name = "Rio de Janeiro Carnival",
                        CityName = "Rio de Janeiro",
                        Price = 2500.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1483729558449-99ef09a8c325",
                        Content = "<p>Join the world's most famous party! Experience the vibrant parades, samba music, and stunning beaches of Rio during Carnival.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 5, 5),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "c8d9e0f1-4a3b-4cbe-5e6f-6d5c4b3a2f18",
                        Name = "Prague Old Town",
                        CityName = "Prague",
                        Price = 1100.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1541849541-09ce6311e891",
                        Content = "<p>Stroll through the cobblestone streets of Prague's historic Old Town. See the Astronomical Clock, Charles Bridge, and Prague Castle.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 4, 19),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "d9e0f1a2-5b4c-4daf-6f7a-7e6d5c4b3a19",
                        Name = "Amsterdam Canal Cruise",
                        CityName = "Amsterdam",
                        Price = 900.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1534351590667-b8c8c3566fe0",
                        Content = "<p>Discover Amsterdam's unique charm from its iconic canals. This cruise offers a new perspective on the city's historic architecture.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 3, 22),
                        IsActive = true
                    },
                    new Trip
                    {
                        Id = "f1a2b3c4-7d6e-4f10-8b9c-9e8f7d6c5b21",
                        Name = "Bavarian Alps Hiking",
                        CityName = "Munich",
                        Price = 1400.00m,
                        ImageUrl = "https://images.unsplash.com/photo-1519643381401-22c77e60520e",
                        Content = "<p>Hike through the stunning scenery of the Bavarian Alps. Visit fairytale castles and enjoy the fresh mountain air in southern Germany.</p>",
                        OwnerId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1",
                        Created = new DateTime(2023, 2, 10),
                        IsActive = true
                    }
                };
    }
}