using Booking.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.DTOs
{
    public class GetAllReservationsQueryParamsDto : GetAllQueryDto
    {
        public decimal Price { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? Status { get; set; }
        public string? CustomerName { get; set; }
        }
}
