using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Web;

namespace SellStuff.Areas.Customer.Bookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : Controller
	{
		private readonly UserManager<User> _userManager;

		public BookingsController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		//public IActionResult Index()
		//{
		//	return View();
		//}

		public async Task<IActionResult> Create()
		{

			var user = await _userManager.GetUserAsync(this.User);
			string url = "/identity/account/login?returnUrl=" + "/bookings/create";

			if (user == null)
			{
				return Redirect(url);
			}

			return View();
		}

		[HttpPost]
		public ActionResult setBookings (int brandValue)
		{
			return Content("Hello");
		}
	}
}
