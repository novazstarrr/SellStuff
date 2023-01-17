using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Customer.Bookings.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
