using Booking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Reservation:BaseEntity<string>
    {
        public string ReservedByUserId { get; set; }
        public virtual User? ReservedByUser { get; set; }
        public string CustomerName { get; set; }
        public string TripId { get; set; }
        public virtual Trip? Trip { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string? Notes { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }
}
   
