using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Bookings
{
    internal class BookingsRepository : BaseRepository, IBookingsRepository
    {
        public BookingsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            await Context.Bookings.AddAsync(booking);

            await Context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking?> GetBookingById(int bookingId)
        {
            return await Context.Bookings
                .AsNoTracking()
                .FirstOrDefaultAsync(booking => booking.Id == bookingId);
        }

        public async Task<IEnumerable<Booking>> GetBookingsBetweenDates(DateTime startDate, DateTime endDate)
        {
            var bookings = await Context.Bookings
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Model)
                .Where(e => e.BookingDateTime.Date >= startDate && e.BookingDateTime.Date <= endDate)
                .OrderByDescending(e => e.BookingDateTime)
                .ToListAsync();

            return bookings;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserId(string userId)
        {
            var bookings = await Context.Bookings
                .AsNoTracking()
                .Where(booking => booking.UserId == userId)
                .OrderByDescending(booking => booking.BookingDateTime)
                .ToListAsync();

            return bookings;
        }

        public async Task<Booking> CompleteBooking(int bookingId)
        {
            var booking = await Context.Bookings.FirstOrDefaultAsync(booking => booking.Id == bookingId);

            if (booking == null)
            {
                throw new Exception($"Could not find a booking with id '{bookingId}'");
            }

            booking.IsCompleted = true;

            Context.Bookings.Update(booking);
            await Context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> CancelBooking(int bookingId)
        {
            var booking = await Context.Bookings.FirstOrDefaultAsync(booking => booking.Id == bookingId);

            if (booking == null)
            {
                throw new Exception($"could not find a booking with id'{bookingId}'");
            }

            Context.Bookings.Remove(booking);
            await Context.SaveChangesAsync();

            return booking;


        }
    }
}
