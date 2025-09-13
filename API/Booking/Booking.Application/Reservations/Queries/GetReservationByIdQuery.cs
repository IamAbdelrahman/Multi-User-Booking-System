using Booking.Application.Reservations.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Queries
{
    public class GetReservationByIdQuery : IRequest<ListReservationDTO>
    {
        public string Id { get; set; }
    }
}
