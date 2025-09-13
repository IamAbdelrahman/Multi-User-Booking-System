using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Reservations.DTOs
{
    public class CreateReservationDTO
    {
        [MaxLength(200)]
        public string? CustomerName { get; set; } = null!;
        public string? TripId { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
}

