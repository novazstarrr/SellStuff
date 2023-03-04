using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class memorysizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO dbo.MemorySizes
            (Id, Name)
            VALUES
            (1, '16gb'),
            (2, '32gb'),
            (3, '64gb'),
            (4, '128gb'),
            (5, '256gb');
            
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM dbo.MemorySizes");
        }
    }
}
