using Booking.WebUI.Models;
using Booking.WebUI.Models.DTOs;
using Booking.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Booking.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;
        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            // Get featured trips for homepage
            var trips = await _apiService.GetAsync<List<TripDto>>("trips/featured");
            return View(trips ?? new List<TripDto>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}