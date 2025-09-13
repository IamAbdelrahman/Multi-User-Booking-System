using Microsoft.AspNetCore.Mvc;

namespace Booking.WebUI.Controllers
{
    public class HostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
