using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DatesTimesBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingTimeDefaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinBookingTimeSlotFromNowInHours = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxBookingTimeSlotFromNowInHours = table.Column<short>(type: "smallint", nullable: false),
                    BookingIntervalInMinutes = table.Column<byte>(type: "tinyint", nullable: false),
                    StartOfDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanWorkMonday = table.Column<bool>(type: "bit", nullable: false),
                    CanWorkTuesday = table.Column<bool>(type: "bit", nullable: false),
                    CanWorkWednesday = table.Column<bool>(type: "bit", nullable: false),
                    CanWorkThursday = table.Column<bool>(type: "bit", nullable: false),
                    CanWorkFriday = table.Column<bool>(type: "bit", nullable: false),
                    CanWorkSaturday = table.Column<bool>(type: "bit", nullable: false),
                    CanWorkSunday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTimeDefaults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingTimeHolidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTimeHolidays", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTimeDefaults");

            migrationBuilder.DropTable(
                name: "BookingTimeHolidays");
        }
    }
}
