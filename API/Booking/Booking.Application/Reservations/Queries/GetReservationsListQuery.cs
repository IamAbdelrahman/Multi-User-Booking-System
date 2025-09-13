using AutoMapper;
using Booking.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Application.Reservations.DTOs;
namespace Booking.Application.Reservations.Queries
{
    public class GetReservationsListQuery : IRequest<IEnumerable<ListReservationDTO>> { }
}
