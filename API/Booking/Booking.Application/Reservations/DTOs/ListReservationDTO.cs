using Booking.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.DTOs
{
    public class ListReservationDTO:GetAllQueryDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Notes { get; set; }
        public int TripId { get; set; }
        public string TripName { get; set; }
        public string Status { get; set; }
    }
}
