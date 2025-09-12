using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Booking.Application.Common.Mappings
{
    using AutoMapper;
    using Booking.Application.Reservations.DTOs;
    using Booking.Domain.Entities;
    using Booking.Domain.Enums;

    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            // CreateReservationDTO -> Reservation
            CreateMap<CreateReservationDTO, Reservation>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => ReservationStatus.Pending.ToString()))
                .ReverseMap();

            // UpdateReservationDTO -> Reservation
            CreateMap<UpdateReservationDTO, Reservation>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.TripId, opt => opt.Ignore()) 
                .ForMember(dest => dest.ReservedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            // Reservation -> ListReservationDTO
            CreateMap<Reservation, ListReservationDTO>()
                .ForMember(dest => dest.TripName, opt => opt.MapFrom(src => src.Trip != null ? src.Trip.Name : string.Empty));        }
    }

}
