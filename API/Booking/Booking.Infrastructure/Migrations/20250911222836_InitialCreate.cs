using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    ReservedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TripId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_ReservedByUserId",
                        column: x => x.ReservedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2(3)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripAvailabilities_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2dacdb51-fee9-4479-904c-cafe7dca22a6", 0, "2bc5ed7c-f23c-41b2-8f24-6cde1379cf70", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@email.com", true, "Admin User", false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEO/q6OSHKyNTnPIucWSWuAmTqfZHsqAMA+fnMfFPz28zoy4gwyv9Qy1QTjaAOCnJYg==", null, false, "2O776OTQMPGHNUKGKGVD7EK56EWEHWJ4", false, "admin" },
                    { "3dacdb51-fee9-4479-904c-cafe7dca22a7", 0, "3bc5ed7c-f23c-41b2-8f24-6cde1379cf70", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "host@email.com", true, "Host User", false, null, "HOST@EMAIL.COM", "HOST", "AQAAAAIAAYagAAAAEKPhsE1ZH2ywRVcOxNIhAIIfbvEEEUx9a0cKblC7AG3bUp7kBN57YBS6h4eiSpcieg==", null, false, "HOSTSTAMP", false, "host" },
                    { "4dacdb51-fee9-4479-904c-cafe7dca22a8", 0, "4bc5ed7c-f23c-41b2-8f24-6cde1379cf70", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "customer@email.com", true, "Customer User", false, null, "CUSTOMER@EMAIL.COM", "CUSTOMER", "AQAAAAIAAYagAAAAEMWTZVZgAJ/EsUyRjvSvhzLikb2SaCnhIAP7KuZmp8g7Gofn24rv/MdjHEUgNyB68w==", null, false, "CUSTOMERTAMP", false, "customer" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CityName", "Content", "Created", "ImageUrl", "IsActive", "Name", "OwnerId", "Price" },
                values: new object[,]
                {
                    { "new-id-for-trip-amsterdam", "Amsterdam", "<p>Discover Amsterdam's unique charm from its iconic canals. This cruise offers a new perspective on the city's historic architecture.</p>", new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1534351590667-b8c8c3566fe0", true, "Amsterdam Canal Cruise", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 900.00m },
                    { "new-id-for-trip-bavarian-alps", "Munich", "<p>Hike through the stunning scenery of the Bavarian Alps. Visit fairytale castles and enjoy the fresh mountain air in southern Germany.</p>", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1519643381401-22c77e60520e", true, "Bavarian Alps Hiking", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1400.00m },
                    { "new-id-for-trip-berlin", "Berlin", "<p>Dive into the rich and complex history of Berlin. Visit the Brandenburg Gate, the Berlin Wall Memorial, and Museum Island.</p>", new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1467269204594-9661b64199da", true, "Berlin History Tour", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1050.00m },
                    { "new-id-for-trip-cairo", "Cairo", "<p>Uncover the mysteries of ancient Egypt. This trip includes a visit to the Giza pyramids, the Sphinx, and the Egyptian Museum.</p>", new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1539768979805-0d4b4e891edf", true, "Cairo & Pyramids", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1800.00m },
                    { "new-id-for-trip-dubai", "Dubai", "<p>Experience the thrill of a desert safari with dune bashing, camel riding, and a traditional Arabian dinner under the stars.</p>", new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1512453979798-5ea266f8880c", true, "Dubai Desert Safari", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 700.00m },
                    { "new-id-for-trip-grand-canyon", "Las Vegas", "<p>Take a day trip from Las Vegas to the majestic Grand Canyon. This tour includes transportation, lunch, and spectacular photo opportunities.</p>", new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1508739773434-c26b3d09e071", true, "Grand Canyon Adventure", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 650.00m },
                    { "new-id-for-trip-himalayan-trek", "Kathmandu", "<p>Embark on an unforgettable trekking journey through the breathtaking Himalayas. Witness stunning mountain vistas and remote village life.</p>", new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1554119102-285cf5c5a5bd", true, "Himalayan Trek", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 3500.00m },
                    { "new-id-for-trip-iceland", "Reykjavik", "<p>Chase the Aurora Borealis in Iceland. This tour also includes visits to geysers, waterfalls, and the famous Blue Lagoon.</p>", new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1515496281367-1a96cdab32bd", true, "Iceland Northern Lights", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1600.00m },
                    { "new-id-for-trip-kenya", "Nairobi", "<p>Witness the Great Migration in the Maasai Mara. An unforgettable safari experience with up-close encounters with Africa's wildlife.</p>", new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1509817923753-9e0551c691f9", true, "Safari in Kenya", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 4500.00m },
                    { "new-id-for-trip-kyoto", "Kyoto", "<p>Find tranquility in Kyoto. Visit serene Zen gardens, stunning temples, and traditional tea houses. A peaceful escape from the city.</p>", new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1493976040374-85c8e12f2c0e", true, "Kyoto Zen Gardens", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1900.00m },
                    { "new-id-for-trip-machu-picchu", "Cusco", "<p>Hike the Inca Trail or take a scenic train ride to the magnificent lost city of Machu Picchu. An incredible journey through ancient Incan history.</p>", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1509219433878-6d6efcaab3b0", true, "Machu Picchu Explorer", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 2800.00m },
                    { "new-id-for-trip-new-york", "New York", "<p>A whirlwind tour of NYC's highlights, including Times Square, Central Park, and the Statue of Liberty. A trip full of energy and excitement.</p>", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1496442226666-8d4d0e62f167", true, "New York City: The Big Apple", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1750.00m },
                    { "new-id-for-trip-paris", "Paris", "<p>Explore the romantic streets of Paris, from the iconic Eiffel Tower to the historic Louvre Museum. This trip includes a Seine River cruise and a visit to Notre-Dame.</p>", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1502602898657-3e91760cbb34", true, "Discover Paris: The City of Lights", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1250.00m },
                    { "new-id-for-trip-prague", "Prague", "<p>Stroll through the cobblestone streets of Prague's historic Old Town. See the Astronomical Clock, Charles Bridge, and Prague Castle.</p>", new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1541849541-09ce6311e891", true, "Prague Old Town", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1100.00m },
                    { "new-id-for-trip-rio", "Rio de Janeiro", "<p>Join the world's most famous party! Experience the vibrant parades, samba music, and stunning beaches of Rio during Carnival.</p>", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1483729558449-99ef09a8c325", true, "Rio de Janeiro Carnival", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 2500.00m },
                    { "new-id-for-trip-rome", "Rome", "<p>Step back in time as you explore the Colosseum, Roman Forum, and Pantheon. Our expert guides will bring the history of the Roman Empire to life.</p>", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1552832230-c0197dd311b5", true, "Rome: Ancient Wonders", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1350.00m },
                    { "new-id-for-trip-santorini", "Santorini", "<p>Experience the legendary sunset of Santorini from a luxury catamaran. Includes dinner and swimming stops in the Aegean Sea.</p>", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff", true, "Santorini Sunset Cruise", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 1500.00m },
                    { "new-id-for-trip-sydney", "Sydney", "<p>Sail across the iconic Sydney Harbour, with spectacular views of the Opera House and Harbour Bridge. A perfect way to see the city.</p>", new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1506973035872-a4ec16b8e8d9", true, "Sydney Harbour Tour", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 850.00m },
                    { "new-id-for-trip-tokyo", "Tokyo", "<p>Experience the vibrant energy of Tokyo. Visit ancient temples in Asakusa, explore the bustling Shibuya Crossing, and indulge in world-class Japanese cuisine.</p>", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1542051841857-5f90071e79859", true, "Tokyo: Modern Meets Tradition", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 2100.00m },
                    { "new-id-for-trip-venice", "Venice", "<p>Glide through the enchanting canals of Venice on a traditional gondola. Discover hidden gems and enjoy the unique charm of this floating city.</p>", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.unsplash.com/photo-1511527661048-7fe73d8e441f", true, "Venice Canal Tour", "3dacdb51-fee9-4479-904c-cafe7dca22a7", 950.00m }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckIn", "CheckOut", "CreatedAt", "CustomerName", "Notes", "ReservationDate", "ReservedByUserId", "Status", "TripId" },
                values: new object[,]
                {
                    { "a2c7e8f3-0b5a-9a1a-6d5e-2c3d4e5f6091", new DateTime(2024, 11, 20, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 25, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 5, 12, 0, 0, 0, DateTimeKind.Utc), "Liam O'Connor", "Includes celebration package during the trip.", new DateTime(2024, 10, 5, 12, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-paris" },
                    { "a6f1b2c7-4e9c-4d5d-0a9b-6f7a8b9c0d35", new DateTime(2024, 4, 5, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 9, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 1, 7, 45, 0, 0, DateTimeKind.Utc), "Frank Liu", "Requests extra towels at accommodation.", new DateTime(2024, 3, 1, 7, 45, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Pending", "new-id-for-trip-venice" },
                    { "a8b3c4d9-6a1c-5f7f-2c1d-8bcde17", new DateTime(2025, 7, 18, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 7, 22, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 6, 12, 13, 0, 0, 0, DateTimeKind.Utc), "Rita Gomez", "Requires accessible accommodation during the trip.", new DateTime(2025, 6, 12, 13, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-paris" },
                    { "b1a6c8a2-9f4e-4f0d-8b4b-1a2d3e4f5a60", new DateTime(2023, 10, 1, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 5, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Utc), "Alice Johnson", "Prefers quiet accommodation room and late check-in for the trip.", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-paris" },
                    { "b3c8a9d4-1a6a-0b2b-7c6d-3c4d5e6f7102", new DateTime(2024, 12, 24, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 31, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 11, 11, 9, 0, 0, 0, DateTimeKind.Utc), "Maya Patel", "Holiday trip booking.", new DateTime(2024, 11, 11, 9, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Pending", "new-id-for-trip-venice" },
                    { "b7a2c3d8-5f0d-4e6e-1b0c-7a8b9c0d1e46", new DateTime(2024, 5, 1, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 4, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 10, 13, 0, 0, 0, DateTimeKind.Utc), "Gabriela Santos", "Anniversary package requested for trip accommodations.", new DateTime(2024, 4, 10, 13, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-grand-canyon" },
                    { "b9c4d5e0-7a2d-6b8b-3c2d-9cdef18", new DateTime(2025, 8, 15, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 20, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Samuel Reed", null, new DateTime(2025, 8, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Completed", "new-id-for-trip-venice" },
                    { "c2b7d9b3-0a5f-4e1e-9c5c-2b3e4f6a7b81", new DateTime(2024, 2, 10, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 15, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 9, 30, 0, 0, DateTimeKind.Utc), "Bob Smith", "Requests airport pickup for trip arrival.", new DateTime(2024, 1, 5, 9, 30, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Pending", "new-id-for-trip-venice" },
                    { "c4c9d0e5-2a7b-1b3b-8d7e-4c5d6e7f8113", new DateTime(2025, 1, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 15, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Noah Williams", "Booked with \"Ring in the New Year\" trip package.", new DateTime(2024, 12, 1, 10, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-tokyo" },
                    { "c8a3d4e9-6b1e-5f7f-2c1d-8ab9cde57", new DateTime(2024, 7, 15, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 20, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 2, 11, 0, 0, 0, DateTimeKind.Utc), "Hassan Ali", null, new DateTime(2024, 6, 2, 11, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Cancelled", "new-id-for-trip-tokyo" },
                    { "d3c8eac4-1b6f-5f2f-0d6d-3c4f5e8f9c92", new DateTime(2024, 6, 1, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 7, 10, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 20, 12, 0, 0, 0, DateTimeKind.Utc), "Carla Reyes", null, new DateTime(2024, 5, 20, 12, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Cancelled", "new-id-for-trip-tokyo" },
                    { "d5b0c1d6-3a8b-2c4c-9d8e-5bcdef14", new DateTime(2025, 2, 1, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 2, 7, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 15, 11, 30, 0, 0, DateTimeKind.Utc), "Olivia Brown", "Prefers window seat for flights related to the trip.", new DateTime(2025, 1, 15, 11, 30, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-himalayan-trek" },
                    { "d9b4e5f0-7a2f-6c8c-3d2e-9bcdef68", new DateTime(2024, 8, 5, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 12, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 21, 9, 0, 0, 0, DateTimeKind.Utc), "Ivy Chen", "Needs a crib at accommodation during the trip.", new DateTime(2024, 7, 21, 9, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-himalayan-trek" },
                    { "e0c5f6d1-8b3d-7e9e-4e3f-0c1d2e3f4a79", new DateTime(2024, 9, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 14, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 1, 14, 0, 0, 0, DateTimeKind.Utc), "Jack O'Neill", "Late arrival expected for trip check-in.", new DateTime(2024, 8, 1, 14, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Pending", "new-id-for-trip-cairo" },
                    { "e4d9f0a5-2c7a-4b3b-8f7e-4d5e6f7a8b13", new DateTime(2023, 12, 20, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 25, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 2, 8, 15, 0, 0, DateTimeKind.Utc), "Daniel Kim", "Allergic to feather bedding during accommodation.", new DateTime(2023, 11, 2, 8, 15, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-paris" },
                    { "e6b1c2d7-4a9c-3d5d-0a9b-6bcdef15", new DateTime(2025, 4, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 14, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 3, 12, 0, 0, 0, DateTimeKind.Utc), "Peter Novak", null, new DateTime(2025, 3, 3, 12, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Pending", "new-id-for-trip-rome" },
                    { "f1c6d7e2-9b4f-8a0a-5f4e-1c2d3e4f5180", new DateTime(2024, 10, 1, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 3, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 12, 10, 30, 0, 0, DateTimeKind.Utc), "Kara Novak", "Allergic to nuts; please note for trip meals.", new DateTime(2024, 9, 12, 10, 30, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-kyoto" },
                    { "f5e0a1b6-3d8b-4c4c-9f8f-5e6f7a8b9c24", new DateTime(2024, 3, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 12, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 14, 18, 0, 0, 0, DateTimeKind.Utc), "Evelyn Turner", "Vegetarian meals requested for trip dining.", new DateTime(2024, 2, 14, 18, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-rome" },
                    { "f7b2c3d8-5a0d-4e6e-1b0c-7bcdef16", new DateTime(2025, 5, 5, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 9, 11, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 4, 20, 9, 0, 0, 0, DateTimeKind.Utc), "Quinn Harper", "Pescatarian diet requested for trip meals.", new DateTime(2025, 4, 20, 9, 0, 0, 0, DateTimeKind.Utc), "4dacdb51-fee9-4479-904c-cafe7dca22a8", "Confirmed", "new-id-for-trip-grand-canyon" }
                });

            migrationBuilder.InsertData(
                table: "TripAvailabilities",
                columns: new[] { "Id", "EndDate", "IsAvailable", "StartDate", "TripId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-id-for-trip-paris" },
                    { 2, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-id-for-trip-venice" },
                    { 3, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-id-for-trip-tokyo" },
                    { 4, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-id-for-trip-rome" },
                    { 5, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-id-for-trip-grand-canyon" },
                    { 6, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "new-id-for-trip-himalayan-trek" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CheckIn",
                table: "Reservations",
                column: "CheckIn");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CheckOut",
                table: "Reservations",
                column: "CheckOut");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedByUserId",
                table: "Reservations",
                column: "ReservedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Status",
                table: "Reservations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripAvailabilities_TripId",
                table: "TripAvailabilities",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CityName",
                table: "Trips",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_IsActive",
                table: "Trips",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Name",
                table: "Trips",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_OwnerId",
                table: "Trips",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Price",
                table: "Trips",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "TripAvailabilities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
