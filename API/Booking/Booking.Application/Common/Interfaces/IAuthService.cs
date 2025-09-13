using Booking.Domain.Entities;
using Booking.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces
{
    public interface IAuthService
    {
        public void SetAccessTokenCookie(HttpContext ctx, string token);
        public void UnsetAccessTokenCookie(HttpContext ctx);
        public string CreateToken(User user);
        public string ExtractUsernameFromEmail(string email);

    }
}
