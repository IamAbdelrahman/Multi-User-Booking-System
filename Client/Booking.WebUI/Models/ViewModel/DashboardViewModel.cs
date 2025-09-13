using Booking.WebUI.Models.DTOs;

namespace Booking.WebUI.Models.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalTrips { get; set; }
        public int TotalReservations { get; set; }
        public int TotalUsers { get; set; }
        public decimal TotalRevenue { get; set; }
        public int PendingReservations { get; set; }
        public List<ReservationDto> RecentReservations { get; set; }
        public List<TripDto> PopularTrips { get; set; }
    }
}