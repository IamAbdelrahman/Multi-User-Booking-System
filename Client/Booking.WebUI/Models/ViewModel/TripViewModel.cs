using System.ComponentModel.DataAnnotations;

namespace Booking.WebUI.Models.ViewModel
{
    public class TripViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Trip name is required")]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [StringLength(100)]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string ImageUrl { get; set; } = "/images/default.jpg";

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}