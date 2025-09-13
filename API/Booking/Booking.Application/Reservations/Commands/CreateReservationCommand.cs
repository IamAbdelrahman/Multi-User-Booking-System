using Booking.Application.Reservations.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Commands
{
    public class CreateReservationCommand : IRequest<CreateReservationDTO>
    {
        public string TripId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
