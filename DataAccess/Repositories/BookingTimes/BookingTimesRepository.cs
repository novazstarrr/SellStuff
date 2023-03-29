using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Repositories
{
    internal class BookingTimesRepository : BaseRepository, IBookingTimesRepository
    {
        public BookingTimesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BookingTimeDefaults> GetBookingTimeDefaults()
        {
            var bookingDefaults = await Context.BookingTimeDefaults.FirstOrDefaultAsync();

            if (bookingDefaults == null) {
                throw new ApplicationException("No booking time defaults were found in the database. You must populate this information.");
            }

            return bookingDefaults;
        }

        public async Task<IEnumerable<BookingTimeHoliday>> GetBookingTimeHolidays(DateTime dateFrom, DateTime dateTo)
        {
            var holidays = await Context.BookingTimeHolidays
                .Where(holiday =>
                    holiday.Start >= dateFrom && holiday.Start <= dateTo ||
                    holiday.End >= dateFrom && holiday.End <= dateTo ||
                    holiday.Start <= dateFrom && holiday.End >= dateTo
                )
                .ToListAsync();

            return holidays;
        }
    }
}