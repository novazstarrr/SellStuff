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
            (1, '16GB'),
            (2, '32GB'),
            (3, '64GB'),
            (4, '128GB'),
            (5, '256GB'),
            (6, '512GB'),
            (7, '1TB');
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
