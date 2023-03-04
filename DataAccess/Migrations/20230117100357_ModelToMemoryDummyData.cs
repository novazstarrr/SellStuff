using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModelToMemoryDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DECLARE @16GBId TINYINT = 1;
DECLARE @32GBId TINYINT = 2;
DECLARE @64GBId TINYINT = 3;
DECLARE @128GBId TINYINT = 4;
DECLARE @256GBId TINYINT = 5;
DECLARE @IPHONE6 TINYINT = 1;
DECLARE @IPHONE6S TINYINT = 2;
DECLARE @IPHONE7 TINYINT = 3;
DECLARE @IPHONE7PLUS TINYINT = 4;
DECLARE @IPHONE8 TINYINT = 5;
DECLARE @IPHONE8PLUS TINYINT = 6;
DECLARE @IPHONEX TINYINT = 7;
DECLARE @IPADAIR2 TINYINT = 8;

INSERT INTO ModelsToMemorySizes
(ModelId, MemorySizeId)
VALUES
(@IPHONE6, @16GbId),
(@IPHONE6, @32GBId),
(@IPHONE6, @64GBId),
(@IPHONE7, @32GBId),
(@IPHONE7, @64GBId),
(@IPHONE7, @128GBId),
(@IPHONE7, @256GBId),
(@IPHONE7PLUS, @32GBId),
(@IPHONE7PLUS, @128GBId),
(@IPHONE7PLUS, @256GBId),
(@IPHONE8, @64GBId),
(@IPHONE8, @128GBId),
(@IPHONE8, @256GBId),
(@IPHONE8PLUS, @128GBId),
(@IPHONEX, @64GBId),
(@IPHONEX, @256GBId),
(@IPADAIR2, @32GBId),
(@IPADAIR2, @128GBId),
(@IPADAIR2, @256GBId);


");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM dbo.ModelsToMemorySizes;
                    ");

        }
    }
}
