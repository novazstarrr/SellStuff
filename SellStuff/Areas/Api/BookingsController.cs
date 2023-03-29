using DataAccess.Repositories.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Utility;

namespace SellStuff.Areas.Api
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class BookingsController : Controller
	{
		private readonly IBookingsRepository _bookingsRepository;
		
		public BookingsController(IBookingsRepository bookingsRepository)
		{
			_bookingsRepository = bookingsRepository;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetById([FromRoute] string userId)
		{
			var retrievedId = await _bookingsRepository.GetBookingsByUserId(userId);

			return new JsonResult(retrievedId);
		}

		[HttpGet]
		[Authorize(Roles = SD.Role_Admin)]
		public async Task<IActionResult> GetBookingsByDates([FromQuery] DateTime startDate, DateTime endDate)
		{
			var retrieveBookings = await _bookingsRepository.GetBookingsBetweenDates(startDate, endDate);

			return new JsonResult(retrieveBookings);
		}

		[HttpPost("{bookingId}/complete")]
		[Authorize(Roles = SD.Role_Admin)]
		public async Task<IActionResult> CompleteBooking (int bookingId)
		{
			var booking = await _bookingsRepository.GetBookingById(bookingId);

			if (booking == null)
			{
				return NotFound();
			}

			if (booking.IsCompleted)
			{
				return BadRequest("Cannot complete an already completed booking");
			}

			if (booking.IsCancelled)
			{
				return BadRequest("Cannot complete an already cancelled booking");
			}

			booking = await _bookingsRepository.CompleteBooking(bookingId);

			return Ok(booking);
		}

		[HttpPost("{bookingId}/cancel")]
		[Authorize(Roles = SD.Role_Admin)]
		public async Task<IActionResult> CancelBooking (int bookingId)
		{
			var booking = await _bookingsRepository.GetBookingById(bookingId);

			if (booking == null)
			{
				return NotFound();
			}

			if (booking.IsCancelled)
			{
				return BadRequest("Cannot complete an already cancelled booking");
			}

			booking = await _bookingsRepository.CancelBooking(bookingId);

			return Ok(booking);
		}



	}
}
