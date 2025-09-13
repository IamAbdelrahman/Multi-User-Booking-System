using Booking.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Commands
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IReservationRepository _repo;

        public DeleteReservationCommandHandler(IReservationRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _repo.GetByIdAsync(request.Id);
            if (reservation == null)
                throw new KeyNotFoundException($"Reservation with ID {request.Id} not found.");

            await _repo.DeleteAsync(reservation.Id);
        }

    }
}
