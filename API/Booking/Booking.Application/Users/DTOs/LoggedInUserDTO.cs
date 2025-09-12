using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Users.DTOs
{
    public record LoggedInUserDTO
    {
        public string Id { get; init; }
        public string UserName { get; init; }
        public List<string> Roles { get; init; }
        public bool IsInRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                return false;

            return Roles.Contains(role, StringComparer.OrdinalIgnoreCase);
        }
    }
}
