using Booking.WebUI.Models.DTOs;
using System.ComponentModel.DataAnnotations;
namespace Booking.WebUI.Models.ViewModel
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Trip is required")]
        public int TripId { get; set; }
        public string TripName { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Check-in date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        public string Notes { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";
        public List<TripDto> AvailableTrips { get; set; }
    }
}