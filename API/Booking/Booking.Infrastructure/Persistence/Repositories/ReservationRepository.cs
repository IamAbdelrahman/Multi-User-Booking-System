using AutoMapper;
using Booking.Application.Common;
using Booking.Application.Common.Interfaces;
using Booking.Application.Reservations.DTOs;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Repositories
{
    public class ReservationRepository:GenericRepository<Reservation, string>, IReservationRepository
    {
        public ReservationRepository(BookingDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

    }
}
