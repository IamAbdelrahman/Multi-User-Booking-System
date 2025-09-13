namespace Booking.WebUI.Models.DTOs
{
    public class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
