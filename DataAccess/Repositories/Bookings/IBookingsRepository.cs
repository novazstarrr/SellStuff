using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Bookings
{
    public interface IBookingsRepository
    {
        Task<Booking> CreateBooking(Booking booking);

        Task<Booking?> GetBookingById(int bookingId);

        Task<IEnumerable<Booking>> GetBookingsByUserId(string userId);

        Task<IEnumerable<Booking>> GetBookingsBetweenDates(DateTime startDate, DateTime endDate);

        Task<Booking> CompleteBooking(int bookingId);

        Task<Booking> CancelBooking(int bookingId);
    }
}
