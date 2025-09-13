using AutoMapper;
using Booking.Application.Common.Resolvers;
using Booking.Application.Users.DTOs;
using Booking.Domain.Entities;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // RegisterDto → User
        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.FullName,
                       opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.CreatedAt,
                       opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<User, RegisterDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom<FullNameToFirstNameResolver>())
            .ForMember(dest => dest.LastName, opt => opt.MapFrom<FullNameToLastNameResolver>());

        CreateMap<LoginDto, User>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore()) // Roles will be set manually
            .ForMember(dest => dest.Token, opt => opt.Ignore()); // Token will be set manually
    }
}
