using AutoMapper;
using Booking.Application.Common.Interfaces;
using Booking.Application.Reservations.DTOs;
using Booking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Commands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, CreateReservationDTO>
    {
        private readonly IReservationRepository _repo;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IReservationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CreateReservationDTO> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = _mapper.Map<Reservation>(request);
            await _repo.AddAsync(reservation);
            return _mapper.Map<CreateReservationDTO>(reservation);
        }
    }
}
