namespace Booking.WebUI.Models.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string ReservedByUserId { get; set; }
        public string CustomerName { get; set; }
        public int TripId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public TripDto Trip { get; set; }
    }
}
