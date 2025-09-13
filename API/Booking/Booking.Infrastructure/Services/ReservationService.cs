using AutoMapper;
using Booking.Application.Common.Interfaces;
using Booking.Application.Reservations.DTOs;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationService> _logger;
        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReservationService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Reservation> CreateBookingAsync(string userId, CreateReservationDTO dto)
        {
            var trip = await _unitOfWork.TripRepo.GetByIdAsync(dto.TripId,
                x => x.Owner, x => x.TripAvailabilities);

            if (trip == null)
                throw new KeyNotFoundException($"Trip with ID {dto.TripId} not found.");

            //Check trip is available for the selected dates
            var isAvailable = await IsTripAvailable(trip, dto.CheckIn, dto.CheckOut);
            if (!isAvailable)
                throw new InvalidOperationException("The trip is not available for the selected dates.");

            //If yes and user reserve this trip marks as unavailable
            //Update:this trip blocks them as they are booked now so any coming guest cannot book them
            await UpdateAvailabilityRecordsAsync(trip, dto.CheckIn, dto.CheckOut);

            var reservation = _mapper.Map<Reservation>(dto);
            await _unitOfWork.ReservationRepo.AddAsync(reservation);
            await _unitOfWork.CompleteAsync();
            return reservation;
        }

        private async Task<bool> IsTripAvailable(Trip trip, DateTime checkIn, DateTime checkOut)
        {
            // Check if the trip has any availability that covers the requested dates
            var checkAvailable = await _unitOfWork.TripAvailabilitiyRepo.FetchAllAsync(t =>
                t.TripId == trip.Id &&
                t.IsAvailable == true &&
                t.StartDate <= checkIn && t.EndDate >= checkOut
                );

            if (!checkAvailable.Any())
            {
                _logger.LogWarning($"Trip {trip.Id} is not available from {checkIn} to {checkOut}");
                return false;
            }
            // 3. Check that the availability windows fully cover the desired range without gaps
            DateTime currentCoverage = checkIn;

            foreach (var availability in checkAvailable)
            {
                if (availability.StartDate > currentCoverage)
                    return false; // Gap found — property not available for full duration

                if (availability.EndDate > currentCoverage)
                    currentCoverage = availability.EndDate;

                if (currentCoverage >= checkOut)
                    return true; //  Full coverage confirmed
            }

            return currentCoverage >= checkOut; // Check final coverage in case last range reaches end
        }

        private async Task UpdateAvailabilityRecordsAsync(Trip trip, DateTime checkIn, DateTime checkOut)
        {
            /* 
             * Here assume customer chooses a trip may be available during multiple date periods.
                We need to find all availability records that overlap with the booking dates
                Available 1-->11 and books 5-->10 (Available)
                Anoother Guest books 4-->8 (Unavailable) but 1-->5  is available 
                as mean 1,2,3,4 and 5 checkout excluded and 10 -->11 is available (overlaps)
            */

            var overlappingAvailabilities = trip.TripAvailabilities
                .Where(a => a.StartDate <= checkOut && a.EndDate >= checkIn && a.IsAvailable)
                .OrderBy(a => a.StartDate)
                .ToList();

            var date = trip.TripAvailabilities.Select(a => a.StartDate).ToList();

            //Anoother Guest books 4-->8 (Unavailable) but 1-->5 is available and 10 -->11 is available (overlaps)
            //Loop through each overlapping availability
            foreach (var availability in overlappingAvailabilities)
            {
                // Case 1: Availability record is completely within the booking period
                if (availability.StartDate >= checkIn && availability.EndDate <= checkOut)
                {
                    // Mark entire record as unavailable
                    availability.IsAvailable = false;
                    await _unitOfWork.TripAvailabilitiyRepo.UpdateAsync(availability);
                    continue;
                }

                // Case 2: Booking starts within this availability period
                if (availability.StartDate < checkIn && availability.EndDate > checkIn)
                {
                    // Split into available (before) and unavailable (during) parts
                    var before = new TripAvailability
                    {
                        TripId = trip.Id,
                        StartDate = availability.StartDate,
                        EndDate = checkIn,
                        IsAvailable = true
                    };

                    var during = new TripAvailability
                    {
                        TripId = trip.Id,
                        StartDate = checkIn,
                        EndDate = availability.EndDate < checkOut ? availability.EndDate : checkOut,
                        IsAvailable = false
                    };

                    await _unitOfWork.TripAvailabilitiyRepo.AddAsync(before);
                    await _unitOfWork.TripAvailabilitiyRepo.AddAsync(during); 
                    await _unitOfWork.TripAvailabilitiyRepo.DeleteAsync(availability.Id);
                    continue;
                }

                // Case 3: Booking ends within this availability period
                if (availability.StartDate < checkOut && availability.EndDate > checkOut)
                {
                    // Split into unavailable (during) and available (after) parts
                    var during = new TripAvailability
                    {
                        TripId = trip.Id,
                        StartDate = availability.StartDate > checkIn ? availability.StartDate : checkIn,
                        EndDate = checkOut,
                        IsAvailable = false
                    };

                    var after = new TripAvailability
                    {
                        TripId = trip.Id,
                        StartDate = checkOut,
                        EndDate = availability.EndDate,
                        IsAvailable = true
                    };

                    await _unitOfWork.TripAvailabilitiyRepo.AddAsync(during);
                    await _unitOfWork.TripAvailabilitiyRepo.AddAsync(after);
                    await _unitOfWork.TripAvailabilitiyRepo.DeleteAsync(availability.Id);
                }
            }
        }

    }
}
