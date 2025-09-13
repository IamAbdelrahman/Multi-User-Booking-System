using Booking.WebUI.Models.ViewModel;
using Booking.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IApiService _apiService;

    public AdminController(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Dashboard()
    {
        var trips = await _apiService.GetListAsync<TripViewModel>("trips");
        var reservations = await _apiService.GetListAsync<ReservationViewModel>("reservations");
        var users = await _apiService.GetListAsync<object>("users"); // Simplified

        var model = new DashboardViewModel
        {
            TotalTrips = trips.Count,
            TotalReservations = reservations.Count,
            TotalUsers = users.Count,
            PendingReservations = reservations.Count(r => r.Status == "Pending")
        };

        return View(model);
    }
}