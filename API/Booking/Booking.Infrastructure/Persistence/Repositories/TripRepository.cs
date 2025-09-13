using AutoMapper;
using Booking.Application.Common.Interfaces;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Repositories
{
    public class TripRepository: GenericRepository<Trip, string>, ITripRepository
    {
        public TripRepository(BookingDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
