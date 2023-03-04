using DataAccess.Repositories.Bookings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Web;

namespace SellStuff.Areas.Customer.Bookings.Controllers
{
	
	public class BookingsController : Controller
	{
		private readonly UserManager<User> _userManager;
		private IBookingsRepository _bookingsRepository;

		public BookingsController(UserManager<User> userManager, IBookingsRepository bookingsRepository)
		{
			_userManager = userManager;
			_bookingsRepository = bookingsRepository;
		}

		
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
		public async Task<IActionResult> SetBookings(short model, byte memorySize, byte grade,
			DateTime dateSelector, DateTime dateTimePicker)
		{
			//var myRepo = _bookingsRepository;
			var userObject = await _userManager.GetUserAsync(this.User);
			string userId = userObject.Id;

			var booking = new Booking();

			booking.ModelId = model;

			booking.MemorySizeId = memorySize;

			booking.GradeId = grade;

			booking.DaySlot = dateSelector;

			booking.TimeSlot = dateTimePicker;

			booking.UserId = userId;

			booking.IsCompleted = false;

			booking.IsCancelled = false;

			return Content("Hello");
		}
	}
}
