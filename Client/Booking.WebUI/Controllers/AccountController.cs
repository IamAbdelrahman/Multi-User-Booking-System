// Controllers/AccountController.cs
using Booking.WebUI.Models.DTOs;
using Booking.WebUI.Models.ViewModel;
using Booking.WebUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Booking.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApiService _apiService;

        public AccountController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                // Call API to authenticate
                var response = await _apiService.PostAsync<ApiResponse<UserDto>>("auth/login", model);

                if (response != null && response.Success)
                {
                    // Create claims for the authenticated user
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, response.Data.Id),
                        new Claim(ClaimTypes.Name, response.Data.UserName),
                        new Claim(ClaimTypes.Email, response.Data.Email)
                    };

                    // Add roles to claims
                    if (response.Data.Roles != null)
                    {
                        foreach (var role in response.Data.Roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    // Store token in session if needed
                    HttpContext.Session.SetString("JWTToken", response.Data.Token);

                    TempData["Success"] = "Login successful!";
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, response?.Message ?? "Invalid login attempt.");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred during login. Please try again.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var response = await _apiService.PostAsync<ApiResponse<UserDto>>("auth/register", model);

                if (response != null && response.Success)
                {
                    TempData["Success"] = "Registration successful! Please login.";
                    return RedirectToAction(nameof(Login));
                }

                ModelState.AddModelError(string.Empty, response?.Message ?? "Registration failed.");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred during registration.");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            TempData["Success"] = "You have been logged out successfully.";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }
    }
}