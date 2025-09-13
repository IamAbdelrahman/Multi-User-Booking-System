using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Booking.WebUI.Models.DTOs;
using Booking.WebUI.Services;
using Booking.WebUI.Models.ViewModel;

namespace Booking.WebUI.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IApiService _apiService;

        public ReservationController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");

            var endpoint = isAdmin ? "reservations" : $"reservations/user/{userId}";
            var reservations = await _apiService.GetAsync<List<ReservationDto>>(endpoint);

            return View(reservations ?? new List<ReservationDto>());
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _apiService.GetAsync<ReservationDto>($"reservations/{id}");

            if (reservation == null)
            {
                TempData["Error"] = "Reservation not found.";
                return RedirectToAction(nameof(Index));
            }

            // Check if user can view this reservation
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!User.IsInRole("Admin") && reservation.ReservedByUserId != userId)
            {
                return Forbid();
            }

            return View(reservation);
        }

        // GET: Reservation/Create
        public async Task<IActionResult> Create(int? tripId)
        {
            var trips = await _apiService.GetAsync<List<TripDto>>("trips");

            var viewModel = new ReservationViewModel
            {
                AvailableTrips = trips ?? new List<TripDto>(),
                TripId = tripId ?? 0,
                CheckIn = DateTime.Today.AddDays(1),
                CheckOut = DateTime.Today.AddDays(3)
            };

            return View(viewModel);
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            if (model.CheckOut <= model.CheckIn)
            {
                ModelState.AddModelError("CheckOut", "Check-out date must be after check-in date.");
            }

            if (!ModelState.IsValid)
            {
                model.AvailableTrips = await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();
                return View(model);
            }

            // Check availability
            var availabilityEndpoint = $"reservations/check-availability?tripId={model.TripId}&checkIn={model.CheckIn:yyyy-MM-dd}&checkOut={model.CheckOut:yyyy-MM-dd}";
            var isAvailable = await _apiService.GetAsync<bool>(availabilityEndpoint);

            if (!isAvailable)
            {
                TempData["Error"] = "The selected dates are not available for this trip.";
                model.AvailableTrips = await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();
                return View(model);
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var reservationDto = new ReservationDto
            {
                ReservedByUserId = userId,
                CustomerName = model.CustomerName,
                TripId = model.TripId,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                Notes = model.Notes,
                Status = "Pending",
                ReservationDate = DateTime.Now
            };

            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _apiService.PostAsync<ApiResponse<ReservationDto>>("reservations", reservationDto, token);

            if (response != null && response.Success)
            {
                TempData["Success"] = "Reservation created successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = response?.Message ?? "Failed to create reservation.";
            model.AvailableTrips = await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();
            return View(model);
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _apiService.GetAsync<ReservationDto>($"reservations/{id}");

            if (reservation == null)
            {
                TempData["Error"] = "Reservation not found.";
                return RedirectToAction(nameof(Index));
            }

            // Check if user can edit this reservation
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!User.IsInRole("Admin") && reservation.ReservedByUserId != userId)
            {
                return Forbid();
            }

            var trips = await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();

            var viewModel = new ReservationViewModel
            {
                Id = reservation.Id,
                CustomerName = reservation.CustomerName,
                TripId = reservation.TripId,
                TripName = reservation.Trip.Name,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                Notes = reservation.Notes,
                Status = reservation.Status,
                ReservationDate = reservation.ReservationDate,
                AvailableTrips = trips
            };

            return View(viewModel);
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationViewModel model)
        {
            // Basic validation
            if (model.CheckOut <= model.CheckIn)
            {
                ModelState.AddModelError("CheckOut", "Check-out date must be after check-in date.");
            }

            if (!ModelState.IsValid)
            {
                model.AvailableTrips = await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();
                return View(model);
            }

            // Fetch existing reservation to verify permissions and existence
            var existing = await _apiService.GetAsync<ReservationDto>($"reservations/{model.Id}");
            if (existing == null)
            {
                TempData["Error"] = "Reservation not found.";
                return RedirectToAction(nameof(Index));
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!User.IsInRole("Admin") && existing.ReservedByUserId != userId)
            {
                return Forbid();
            }

            // Check availability (exclude current reservation)
            var availabilityEndpoint = $"reservations/check-availability?tripId={model.TripId}&checkIn={model.CheckIn:yyyy-MM-dd}&checkOut={model.CheckOut:yyyy-MM-dd}&excludeReservationId={model.Id}";
            var isAvailable = await _apiService.GetAsync<bool>(availabilityEndpoint);

            if (!isAvailable)
            {
                TempData["Error"] = "The selected dates are not available for this trip.";
                model.AvailableTrips = await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();
                return View(model);
            }

            // Map view model to DTO for update
            var reservationDto = new ReservationDto
            {
                Id = model.Id,
                ReservedByUserId = existing.ReservedByUserId, // preserve owner
                CustomerName = model.CustomerName,
                TripId = model.TripId,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                Notes = model.Notes,
                Status = model.Status ?? existing.Status,
                ReservationDate = existing.ReservationDate
            };

            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _apiService.PutAsync<ApiResponse<ReservationDto>>($"reservations/{model.Id}", reservationDto, token);

            if (response != null && response.Success)
            {
                TempData["Success"] = "Reservation updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = response?.Message ?? "Failed to update reservation.";
            model.AvailableTrips = await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();
            return View(model);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _apiService.GetAsync<ReservationDto>($"reservations/{id}");

            if (reservation == null)
            {
                TempData["Error"] = "Reservation not found.";
                return RedirectToAction(nameof(Index));
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!User.IsInRole("Admin") && reservation.ReservedByUserId != userId)
            {
                return Forbid();
            }

            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _apiService.GetAsync<ReservationDto>($"reservations/{id}");
            if (reservation == null)
            {
                TempData["Error"] = "Reservation not found.";
                return RedirectToAction(nameof(Index));
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!User.IsInRole("Admin") && reservation.ReservedByUserId != userId)
            {
                return Forbid();
            }

            var token = HttpContext.Session.GetString("JWTToken");
            var deleted = await _apiService.DeleteAsync($"reservations/{id}", token);

            if (deleted)
            {
                TempData["Success"] = "Reservation deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to delete reservation.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}