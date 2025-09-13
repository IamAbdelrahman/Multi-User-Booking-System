using AutoMapper;
using Booking.Application.Common.Interfaces;
using Booking.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly BookingDbContext _dbContext;
        private readonly IMapper _mapper;
        public UnitOfWork(BookingDbContext dbContext, IMapper mapper) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private IReservationRepository? _reservationRepository;
        private ITripRepository? _tripRepository;
        private ITripAvailabilityRepository? _tripAvailabilityRepository;
        public IReservationRepository ReservationRepo => _reservationRepository ??= new ReservationRepository(_dbContext, _mapper);
        public ITripRepository TripRepo => _tripRepository ??= new TripRepository(_dbContext, _mapper);
        public ITripAvailabilityRepository TripAvailabilitiyRepo => _tripAvailabilityRepository ??= new TripAvailabilityRepository(_dbContext, _mapper);

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
