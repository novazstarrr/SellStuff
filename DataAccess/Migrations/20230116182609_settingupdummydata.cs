using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class settingupdummydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DECLARE @AppleBrandId TINYINT = 1;

INSERT INTO dbo.DeviceTypes
(Id, Name, BrandId)
VALUES
(1, 'iPhone', @AppleBrandId),
(2, 'iPad', @AppleBrandId);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM dbo.DeviceTypes;
            ");
        }
    }
}
