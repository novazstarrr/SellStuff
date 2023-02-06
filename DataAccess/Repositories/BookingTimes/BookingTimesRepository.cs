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
            // dateFrom = 07/02/2023T09:00:00
            // dateTo = 21/02/2023T09:00:00

            // Holidays
            // 10/02/2023T00:00:00 - 12/02/2023T23:59:59 (RETURN)
            // 01/03/2023T00:00:00 - 07/03/2023T23:99:99 (RETURN)
            // 01/02/2023T00:00:00 - 25/03/2023T23:99:99 (RETURN)
            // 01/04/2023 - 10-04-2023 (DO NOT RETURN)
            
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