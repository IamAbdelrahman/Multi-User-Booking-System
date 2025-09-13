using Booking.WebUI.Models.DTOs;
using System.ComponentModel.DataAnnotations;
namespace Booking.WebUI.Models.ViewModel
{
    public class TripListViewModel
    {
        public List<TripDto> Trips { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
    }
}
