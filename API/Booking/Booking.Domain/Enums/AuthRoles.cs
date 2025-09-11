using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Enums
{
    [Flags]
    public enum AuthRoles
    {
        Admin = 1,
        Host = 2,
        Customer = 4,
    }
}
