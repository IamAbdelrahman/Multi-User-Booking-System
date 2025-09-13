using AutoMapper;
using Booking.Application.Common.Interfaces;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence.Repositories
{
    public class TripAvailabilityRepository: GenericRepository<TripAvailability, int>, ITripAvailabilityRepository
    {
        public TripAvailabilityRepository(BookingDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
        public async Task<List<TripAvailability>> FetchAllAsync(Expression<Func<TripAvailability, bool>> filter)
        {
             return await _dbContext.TripAvailabilities.Where(filter).ToListAsync();
        }
    }
}
