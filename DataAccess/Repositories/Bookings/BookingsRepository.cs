using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            Context.Bookings.Update(booking);

            await Context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking?> GetBookingById(int bookingid)
        {
             return await Context.Bookings
                .AsNoTracking()
                .FirstOrDefaultAsync(booking => booking.Id == bookingid);
        }

        public async Task<IEnumerable<BookingAndPrice>> GetBookingsBetweenDates(DateTime startDate, DateTime endDate)
        {
            var bookings = await Context.Bookings
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Grade)
                .Include(x => x.MemorySize)
                .Include(x => x.Model)
                .Join(Context.PricingMatrix, 
                    booking => new { booking.GradeId, booking.MemorySizeId, booking.ModelId },
                    pricingMatrix => new { pricingMatrix.GradeId, pricingMatrix.MemorySizeId, pricingMatrix.ModelId },
                    (booking, pricingMatrix) => new { Booking = booking, PricingMatrix = pricingMatrix })
                .Where(e => e.Booking.BookingDateTime.Date >= startDate && e.Booking.BookingDateTime.Date <= endDate)
                .OrderByDescending(e => e.Booking.BookingDateTime)
                .ToListAsync();

            return bookings.Select(x => new BookingAndPrice
            {
                
                Price = x.PricingMatrix.Price,
                Model = x.Booking.Model,
                Grade = x.Booking.Grade,
                MemorySize = x.Booking.MemorySize,
                User = x.Booking.User,
                Id = x.Booking.Id,
                GradeId = x.Booking.GradeId,
                UserId = x.Booking.UserId,
                IsCancelled = x.Booking.IsCancelled,
                IsCompleted = x.Booking.IsCompleted,
                MemorySizeId = x.Booking.MemorySizeId,
                ModelId = x.Booking.ModelId,
                BookingDateTime = x.Booking.BookingDateTime
            });
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserId(string userId)
        {
            var bookings = await Context.Bookings
                .AsNoTracking()
                .Include(x => x.User)
                .Include (x => x.Model)
                    .ThenInclude(m => m.DeviceType)
                        .ThenInclude(dt => dt.Brand)
                .Include(x => x.MemorySize)
                .Include(x => x.Grade)
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

            booking.IsCancelled = true;

            Context.Bookings.Update(booking);
            await Context.SaveChangesAsync();

            return booking;


        }
    }
}
