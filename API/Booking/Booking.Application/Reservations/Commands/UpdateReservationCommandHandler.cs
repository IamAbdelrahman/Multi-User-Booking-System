using AutoMapper;
using Booking.Application.Common.Interfaces;
using Booking.Application.Reservations.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.Commands
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IReservationRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateReservationCommandHandler(IReservationRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Reservation with ID {request.Id} not found.");

            _mapper.Map(request.Dto, existing);

            await _repo.UpdateAsync(existing);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }
    }

}
