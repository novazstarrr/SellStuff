using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BookingPreferencesDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.BookingTimeDefaults
                    (MinBookingTimeSlotFromNowInHours, MaxBookingTimeSlotFromNowInHours, BookingIntervalInMinutes,
                    StartOfDay, EndOfDay, CanWorkMonday, CanWorkTuesday, CanWorkWednesday, CanWorkThursday,
                    CanWorkFriday, CanWorkSaturday, CanWorkSunday)
                Values
                    (24, 72, 60, '2023-02-10 09:00:00.0000000', '2023-02-10 21:00:00.0000000', 1, 1, 1, 1, 1, 0, 0);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
