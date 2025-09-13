using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ITripRepository TripRepo { get; }
        ITripAvailabilityRepository TripAvailabilitiyRepo { get; }
        IReservationRepository ReservationRepo { get; }
        Task<int> CompleteAsync();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
        void Dispose();
    }
}
