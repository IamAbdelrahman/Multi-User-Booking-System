using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common
{
    public static class IdentityResultExtensions
    {
        public static List<string> ToErrorList(this IdentityResult result)
        {
            return result.Errors.Select(e => $"{e.Code}: {e.Description}").ToList();
        }
    }
}
