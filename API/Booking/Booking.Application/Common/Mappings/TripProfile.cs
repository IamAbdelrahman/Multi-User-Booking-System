using AutoMapper;
using Booking.Application.Trips.DTOs;
using Booking.Domain.Entities;

public class TripProfile : Profile
{
    public TripProfile()
    {
        // Trip → ListTripDTO
        CreateMap<Trip, ListTripDTO>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.Created))
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));

        // User → TripOwnerDTO
        CreateMap<User, TripOwnerDTO>().ReverseMap();

        // CreateTripDto → Trip
        CreateMap<CreateTripDto, Trip>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true))
            .ReverseMap();

        // UpdateTripDto → Trip
        CreateMap<UpdateTripDto, Trip>();

    }
}

