using Models.Entities;

namespace DataAccess.Repositories
{
    public interface IBookingTimesRepository
    {
        Task<BookingTimeDefaults> GetBookingTimeDefaults();

        Task<IEnumerable<BookingTimeHoliday>> GetBookingTimeHolidays(DateTime dateFrom, DateTime dateTo);
    }
}