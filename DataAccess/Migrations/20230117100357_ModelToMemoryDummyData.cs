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
DECLARE @512GBId TINYINT = 6;
DECLARE @1TBId TINYINT = 7;
DECLARE @IPHONE6 TINYINT = 1;
DECLARE @IPHONE6PLUS TINYINT = 2;
DECLARE @IPHONE6S TINYINT = 3;
DECLARE @IPHONE6SPLUS TINYINT = 4;
DECLARE @IPHONE7 TINYINT = 5;
DECLARE @IPHONE7PLUS TINYINT = 6;
DECLARE @IPHONE8 TINYINT = 7;
DECLARE @IPHONE8PLUS TINYINT = 8;
DECLARE @IPHONEXR TINYINT = 9;
DECLARE @IPHONEX TINYINT = 10;
DECLARE @IPHONEXS TINYINT = 11;
DECLARE @IPHONEXSMAX TINYINT = 12;
DECLARE @IPHONE11 TINYINT = 13;
DECLARE @IPHONE11PRO TINYINT = 14;
DECLARE @IPHONE11PROMAX TINYINT = 15;
DECLARE @IPHONE12 TINYINT = 16;
DECLARE @IPHONE12PRO TINYINT = 17;
DECLARE @IPHONE12PROMAX TINYINT = 18;
DECLARE @IPHONE12MINI TINYINT = 19;
DECLARE @IPHONE13 TINYINT = 20;
DECLARE @IPHONE13MINI TINYINT = 21;
DECLARE @IPHONE13PRO TINYINT = 22;
DECLARE @IPHONE13PROMAX TINYINT = 23;
DECLARE @IPHONE14 TINYINT = 24;
DECLARE @IPHONE14PLUS TINYINT = 25;
DECLARE @IPHONE14PRO TINYINT = 26;
DECLARE @IPHONE14PROMAX TINYINT = 27;


INSERT INTO dbo.ModelsToMemorySizes
(ModelId, MemorySizeId)
VALUES
(@IPHONE6, @16GbId),
(@IPHONE6, @32GBId),
(@IPHONE6, @64GBId),
(@IPHONE6PLUS, @16GbId),
(@IPHONE6PLUS, @64GBId),
(@IPHONE6PLUS, @128GBId),
(@IPHONE6S, @16GbId),
(@IPHONE6S, @32GBId),
(@IPHONE6S, @64GBId),
(@IPHONE6S, @128GBId),
(@IPHONE6SPLUS, @16GbId),
(@IPHONE6SPLUS, @32GBId),
(@IPHONE6SPLUS, @64GBId),
(@IPHONE6SPLUS, @128GBId),
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
(@IPHONE8PLUS, @64GBId),
(@IPHONE8PLUS, @128GBId),
(@IPHONE8PLUS, @256GBId),
(@IPHONEXR, @64GBId),
(@IPHONEXR, @128GBId),
(@IPHONEXR, @256GBId),
(@IPHONEX, @64GBId),
(@IPHONEX, @256GBId),
(@IPHONEXS, @64GBId),
(@IPHONEXS, @256GBId),
(@IPHONEXS, @512GBId),
(@IPHONEXSMAX, @64GBId),
(@IPHONEXSMAX, @256GBId),
(@IPHONEXSMAX, @512GBId),
(@IPHONE11, @64GBId),
(@IPHONE11, @128GBId),
(@IPHONE11, @256GBId),
(@IPHONE11PRO, @64GBId),
(@IPHONE11PRO, @256GBId),
(@IPHONE11PRO, @512GBId),
(@IPHONE11PROMAX, @64GBId),
(@IPHONE11PROMAX, @256GBId),
(@IPHONE11PROMAX, @512GBId),
(@IPHONE12, @64GBId),
(@IPHONE12, @128GBId),
(@IPHONE12, @256GBId),
(@IPHONE12PRO, @128GBId),
(@IPHONE12PRO, @256GBId),
(@IPHONE12PRO, @512GBId),
(@IPHONE12PROMAX, @128GBId),
(@IPHONE12PROMAX, @256GBId),
(@IPHONE12PROMAX, @512GBId),
(@IPHONE12MINI, @64GBId),
(@IPHONE12MINI, @128GBId),
(@IPHONE12MINI, @256GBId),
(@IPHONE13, @128GBId),
(@IPHONE13, @256GBId),
(@IPHONE13, @512GBId),
(@IPHONE13MINI, @128GBId),
(@IPHONE13MINI, @256GBId),
(@IPHONE13MINI, @512GBId),
(@IPHONE13PRO, @128GBId),
(@IPHONE13PRO, @256GBId),
(@IPHONE13PRO, @512GBId),
(@IPHONE13PRO, @1TBId),
(@IPHONE13PROMAX, @128GBId),
(@IPHONE13PROMAX, @256GBId),
(@IPHONE13PROMAX, @512GBId),
(@IPHONE13PROMAX, @1TBId),
(@IPHONE14, @128GBId),
(@IPHONE14, @256GBId),
(@IPHONE14, @512GBId),
(@IPHONE14PLUS, @128GBId),
(@IPHONE14PLUS, @256GBId),
(@IPHONE14PLUS, @512GBId),
(@IPHONE14PRO, @128GBId),
(@IPHONE14PRO, @256GBId),
(@IPHONE14PRO, @512GBId),
(@IPHONE14PRO, @1TBId),
(@IPHONE14PROMAX, @128GBId),
(@IPHONE14PROMAX, @256GBId),
(@IPHONE14PROMAX, @512GBId),
(@IPHONE14PROMAX, @1TBId);
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
