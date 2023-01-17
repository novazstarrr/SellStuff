using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dummygradedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
 INSERT INTO dbo.Grades
(Id, NAME, DESCRIPTION)
VALUES
('1', 'A', 'No visible marks to the device.'),
('2', 'B', 'Some minor wear and tear to the device.'),
('3', 'C', 'Lots of visible scuffs/scratches to the device.');
            
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DELETE FROM dbo.Grades;
            ");
        }
    }
}
