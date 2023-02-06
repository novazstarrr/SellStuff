using DataAccess.Repositories;
using DataAccess.Repositories.Bookings;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace SellStuff.Areas.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private readonly IBookingTimesRepository _bookingTimesRepository;

        private readonly IBookingsRepository _bookingsRepository;

        public DatesController(IBookingTimesRepository bookingTimesRepository, IBookingsRepository bookingsRepository)
        {
            _bookingTimesRepository = bookingTimesRepository;
            _bookingsRepository = bookingsRepository;
        }

        // /api/dates/available
        // Responsible for retriving available booking dates and times
        [HttpGet("available")]
        public async Task<IActionResult> Get()
        {
            var bookingTimeDefaults = await _bookingTimesRepository.GetBookingTimeDefaults();

            var now = DateTime.Now;
            var bookingStartDateTime = now.AddHours(bookingTimeDefaults.MinBookingTimeSlotFromNowInHours);
            var bookingEndDateTime = now.AddHours(bookingTimeDefaults.MaxBookingTimeSlotFromNowInHours);
            var holidays = await _bookingTimesRepository.GetBookingTimeHolidays(bookingStartDateTime, bookingEndDateTime);
            var currentBookings = await _bookingsRepository.GetBookingsBetweenDates(bookingStartDateTime, bookingEndDateTime);

            // It's 10.13AM
            // We want to create a booking
            // The min booking time slot from now is 24 hours meaning the min booking time slot is 10.13AM tomorrow.
            // The start of your working day is 9AM and each time slot is 1 hour long.
            // Available time slots are 9AM - 10AM, 10AM - 11AM, 11AM - 12AM...

            // StartOfDay = 0001-01-01T09:00:00
            // EndOfDay = 0001-01-01T21:00:00
            var startOfBookingDay = bookingStartDateTime.Date + bookingTimeDefaults.StartOfDay.TimeOfDay;
            var endOfBookingDay = bookingEndDateTime.Date + bookingTimeDefaults.EndOfDay.TimeOfDay;

            var bookingTimeSlots = new List<BookingTimeSlot>();

            var currentTimeSlot = startOfBookingDay;
            while (currentTimeSlot < endOfBookingDay) {
                var from = currentTimeSlot;
                var to = currentTimeSlot.AddMinutes(bookingTimeDefaults.BookingIntervalInMinutes);

                // 1. Check if the time slot falls within any of the holidays, if true, then the timeslot is not available.
                // 2. Check if the time slot falls within any existing bookings. If true, then the timeslot is not available.
                // 3. Check if the time slot is not within the StartOfDay and EndOfDay, then the timeslot is not available.
                // 4. Check if the time slot is on a default day. E.g. bookingTimeDefaults.CanWorkMonday = false, then no time slots on Monday should be available.

                var timeSlotDayOfWeek = from.DayOfWeek;

                bookingTimeSlots.Add(new BookingTimeSlot {
                    From = from,
                    To = to,
                    IsAvailable = true
                });

                currentTimeSlot = currentTimeSlot.AddMinutes(bookingTimeDefaults.BookingIntervalInMinutes);
            }

            return new JsonResult(bookingTimeSlots);
        }
    }
}