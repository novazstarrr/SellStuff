using DataAccess.Repositories;
using DataAccess.Repositories.Bookings;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookingTimeDefaults = await _bookingTimesRepository.GetBookingTimeDefaults();

            var now = DateTime.Now;
            var bookingStartDateTime = now.AddHours(bookingTimeDefaults.MinBookingTimeSlotFromNowInHours);
            var bookingEndDateTime = now.AddHours(bookingTimeDefaults.MaxBookingTimeSlotFromNowInHours);
            var holidays = await _bookingTimesRepository.GetBookingTimeHolidays(bookingStartDateTime, bookingEndDateTime);
            var currentBookings = await _bookingsRepository.GetBookingsBetweenDates(bookingStartDateTime, bookingEndDateTime);

            var startOfBookingDay = bookingStartDateTime.Date + bookingTimeDefaults.StartOfDay.TimeOfDay;
            var endOfBookingDay = bookingEndDateTime.Date + bookingTimeDefaults.EndOfDay.TimeOfDay;

            var bookingTimeSlots = new List<BookingTimeSlot>();

            var currentTimeSlot = startOfBookingDay;
            while (currentTimeSlot < endOfBookingDay)
            {
                var from = currentTimeSlot;
                var to = currentTimeSlot.AddMinutes(bookingTimeDefaults.BookingIntervalInMinutes);
                var isTimeSlotAvailable = true;

                if (from.TimeOfDay < startOfBookingDay.TimeOfDay || from.TimeOfDay > endOfBookingDay.TimeOfDay)
                {
                    currentTimeSlot = currentTimeSlot.AddMinutes(bookingTimeDefaults.BookingIntervalInMinutes);
                    continue;
                }

                // 1. Check if the time slot falls within any of the holidays, if true, then the timeslot is not available.
                isTimeSlotAvailable = !holidays.Any(holiday => from >= holiday.Start && from <= holiday.End);

                // 2. Check if the time slot falls within any existing bookings. If true, then the timeslot is not available.
                if (isTimeSlotAvailable)
                {
                    isTimeSlotAvailable = !currentBookings.Any(booking => booking.BookingDateTime >= from && booking.BookingDateTime <= to);
                }

                // 4. Check if the time slot is false on a default monday.
                if (isTimeSlotAvailable)
                {
                    isTimeSlotAvailable =
                        from.DayOfWeek == DayOfWeek.Monday && bookingTimeDefaults.CanWorkMonday ||
                        from.DayOfWeek == DayOfWeek.Tuesday && bookingTimeDefaults.CanWorkTuesday ||
                        from.DayOfWeek == DayOfWeek.Wednesday && bookingTimeDefaults.CanWorkWednesday ||
                        from.DayOfWeek == DayOfWeek.Thursday && bookingTimeDefaults.CanWorkThursday ||
                        from.DayOfWeek == DayOfWeek.Friday && bookingTimeDefaults.CanWorkFriday ||
                        from.DayOfWeek == DayOfWeek.Saturday && bookingTimeDefaults.CanWorkSaturday ||
                        from.DayOfWeek == DayOfWeek.Sunday && bookingTimeDefaults.CanWorkSunday;
                }

                bookingTimeSlots.Add(new BookingTimeSlot
                {
                    From = from,
                    To = to,
                    IsAvailable = isTimeSlotAvailable
                });

                currentTimeSlot = currentTimeSlot.AddMinutes(bookingTimeDefaults.BookingIntervalInMinutes);
            }

            return new JsonResult(bookingTimeSlots);
        }
    }
}