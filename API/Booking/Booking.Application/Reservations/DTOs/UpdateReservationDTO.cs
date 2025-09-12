using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.DTOs
{
    public class UpdateReservationDTO
    {
        [Required, MaxLength(200)]
        public string CustomerName { get; set; } = null!;

        [Required]
        public DateTime ReservationDate { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
}
