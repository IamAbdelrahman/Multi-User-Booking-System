using Booking.Application.Reservations.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Commands
{
    public class UpdateReservationCommand : IRequest
    {
        public string Id { get; set; } 
        public UpdateReservationDTO Dto { get; set; } = null!;
    }

}
