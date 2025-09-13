// Controllers/TripController.cs
using Booking.WebUI.Models.DTOs;
using Booking.WebUI.Models.ViewModel;
using Booking.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Booking.WebUI.Controllers
{
    public class TripController : Controller
    {
        private readonly IApiService _apiService;

        public TripController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Trip
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            var pageSize = 9;
            var endpoint = $"trips?page={page}&pageSize={pageSize}";

            if (!string.IsNullOrEmpty(search))
                endpoint += $"&search={search}";

            var trips = await _apiService.GetAsync<List<TripDto>>(endpoint);

            var viewModel = new TripListViewModel
            {
                Trips = trips ?? new List<TripDto>(),
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (trips?.Count ?? 0) / pageSize + 1, // This should come from API
                SearchTerm = search
            };

            return View(viewModel);
        }

        // GET: Trip/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var trip = await _apiService.GetAsync<TripDto>($"trips/{id}");

            if (trip == null)
            {
                TempData["Error"] = "Trip not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(trip);
        }

        // GET: Trip/Create
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Create()
        {
            return View(new TripViewModel());
        }

        // POST: Trip/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create(TripViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _apiService.PostAsync<ApiResponse<TripDto>>("trips", model, token);

            if (response != null && response.Success)
            {
                TempData["Success"] = "Trip created successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = response?.Message ?? "Failed to create trip.";
            return View(model);
        }

        // GET: Trip/Edit/5
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Edit(int id)
        {
            var trip = await _apiService.GetAsync<TripDto>($"trips/{id}");

            if (trip == null)
            {
                TempData["Error"] = "Trip not found.";
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new TripViewModel
            {
                Id = trip.Id,
                Name = trip.Name,
                CityName = trip.CityName,
                Price = trip.Price,
                ImageUrl = trip.ImageUrl,
                Content = trip.Content
            };

            return View(viewModel);
        }

        // POST: Trip/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Edit(int id, TripViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _apiService.PutAsync<ApiResponse<TripDto>>($"trips/{id}", model, token);

            if (response != null && response.Success)
            {
                TempData["Success"] = "Trip updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = response?.Message ?? "Failed to update trip.";
            return View(model);
        }

        // GET: Trip/Delete/5
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _apiService.GetAsync<TripDto>($"trips/{id}");

            if (trip == null)
            {
                TempData["Error"] = "Trip not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(trip);
        }

        // POST: Trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var success = await _apiService.DeleteAsync($"trips/{id}", token);

            if (success)
            {
                TempData["Success"] = "Trip deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to delete trip.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}