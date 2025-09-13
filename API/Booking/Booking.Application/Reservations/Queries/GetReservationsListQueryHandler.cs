using AutoMapper;
using Booking.Application.Common;
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
    //public class GetReservationsListQueryHandler : IRequestHandler<GetReservationsListQuery, IEnumerable<ListReservationDTO>>
    //{
    //    private readonly IReservationRepository _repo;
    //    private readonly IMapper _mapper;

    //    public GetReservationsListQueryHandler(IReservationRepository repo, IMapper mapper)
    //    {
    //        _repo = repo;
    //        _mapper = mapper;
    //    }

    //    public async Task<IEnumerable<ListReservationDTO>> Handle(GetReservationsListQuery request, CancellationToken cancellationToken)
    //    {
    //        var reservations = await _repo.GetAll();
    //        return _mapper.Map<IEnumerable<ListReservationDTO>>(reservations);
    //    }
    //}

}
