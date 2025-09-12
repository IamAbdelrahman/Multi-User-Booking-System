using AutoMapper;
using Booking.Application.Users.DTOs;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Resolvers
{
    public class FullNameToLastNameResolver : IValueResolver<User, RegisterDto, string>
    {
        public string Resolve(User source, RegisterDto destination, 
            string destMember, ResolutionContext context)
        {
            return source.FullName?.Split(' ', 
                StringSplitOptions.RemoveEmptyEntries).Skip(1).FirstOrDefault() ?? "";
        }
    }
}
