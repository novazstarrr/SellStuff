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

        public async Task<Booking> AddCompletedBooking(Booking booking)
        {
            await Context.Bookings.AddAsync(booking);

            await Context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> GetBookingById(int? bookingId)
        {
            //i want to use .first or default
            if (bookingId == null)
            {
                return
                RedirectToAction("Index");
            }
            var bookings = await Context.Bookings
                .AsNoTracking()
                .Where(u => u.Id == bookingId)
                .OrderByDescending(u => u.TimeSlot)
                .ToListAsync();
        }

        public Task<IEnumerable<Booking>> GetBookingsBetweenDates(DateTime startDate, DateTime endDate)
        {
            //figure it out.
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserId(string userId)
        {
            var bookings = await Context.Bookings
                .AsNoTracking()
                .Where(booking => booking.UserId == userId)
                .OrderByDescending(booking => booking.TimeSlot)
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

        public Task<Booking> CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

		Task<Booking> IBookingsRepository.CreateBooking(Booking booking)
		{
			throw new NotImplementedException();
		}

		Task<Booking> IBookingsRepository.SetBookingIsComplete(int bookingId)
		{
			throw new NotImplementedException();
		}

		Task<Booking> IBookingsRepository.GetBookingById(int bookingId)
		{
			throw new NotImplementedException();
		}

		Task<IEnumerable<Booking>> IBookingsRepository.GetBookingsByUserId(string userId)
		{
			throw new NotImplementedException();
		}

		Task<IEnumerable<Booking>> IBookingsRepository.GetBookingsBetweenDates(DateTime startDate, DateTime endDate)
		{
			throw new NotImplementedException();
		}

		Task<Booking> IBookingsRepository.CompleteBooking(int bookingId)
		{
			throw new NotImplementedException();
		}

		Task<Booking> IBookingsRepository.CancelBooking(int bookingId)
		{
			throw new NotImplementedException();
		}
	}
}
