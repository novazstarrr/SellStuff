using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Api
{
	public class BookingsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
