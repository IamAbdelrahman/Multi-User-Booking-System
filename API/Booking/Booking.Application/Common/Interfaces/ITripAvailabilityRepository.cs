using Booking.Application.Trips.DTOs;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces
{
    public interface ITripAvailabilityRepository: IGenericRepository<TripAvailability, int>
    {
        Task<List<TripAvailability>> FetchAllAsync(Expression<Func<TripAvailability, bool>> filter);
    }
}
