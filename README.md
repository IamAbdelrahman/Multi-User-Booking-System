# 🏨 Booking API (ASP.NET Core 9 + EF Core 9)

A simple **multi-user booking Web API** built with **ASP.NET Core 9** and **Entity Framework Core 9** using the **code-first approach**.  

This project was implemented as part of a technical assignment for the **Junior .NET ASP.NET Core Developer** role.  

---

## 📌 Features
- User, Trip, and Reservation domain models
- Reservation CRUD APIs (RESTful)
- Code-first approach with EF Core migrations
- Database seeding for **Users** and **Trips**
- Multi-layered architecture (API, Application, Domain, Infrastructure)
- Proper error handling (validation + not found)
- Swagger API documentation
- Git history with multiple commits for clarity
- Simple UI using Razor Pages (separate project)
- Repository & Unit of Work patterns
- CQRS + Mediator pattern

---

## 🏗️ Project Structure

```bash
BookingSolution.sln
├── API
│   ├── Booking.Api             # Web API (Controllers, Swagger, DI setup)
│   ├── Booking.Application     # DTOs, Services, Mapping
│   ├── Booking.Domain          # Entities (User, Trip, Reservation)
│   ├── Booking.Infrastructure  # EF Core DbContext, Migrations, Repositories
│ 
└──
```

## ⚙️ Tech Stack
- **.NET 9 SDK**
- **ASP.NET Core 9 Web API**
- **Entity Framework Core 9**
- **SQL Server (default)**
- **Swashbuckle.AspNetCore (Swagger)**
- *(optional)* AutoMapper, MediatR, FluentValidation

---

## 🚀 Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/<your-username>/booking-api.git
cd API
```

### 2. Set up the database
Make sure SQL Server is running and update the connection string in
```bash /src/Booking.Api/appsettings.json ```
Example:-
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BookingDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
### 3. Run migration and seed data
```bash
dotnet ef migrations add InitialCreate -p src/Booking.Infrastructure -s src/Booking.Api
dotnet ef database update -p src/Booking.Infrastructure -s src/Booking.Api
```
### 4. Run the API
```bash
dotnet run --project src/Booking.Api
```



