using AutoMapper;
using Booking.Application.Common.Interfaces;
using Booking.Application.Reservations.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Queries
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ListReservationDTO>
    {
        private readonly IReservationRepository _repo;
        private readonly IMapper _mapper;

        public GetReservationByIdQueryHandler(IReservationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ListReservationDTO> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _repo.GetByIdAsync(request.Id);
            if (reservation == null)
                throw new KeyNotFoundException($"Reservation with ID {request.Id} not found.");

            return _mapper.Map<ListReservationDTO>(reservation);
        }
    }
}
