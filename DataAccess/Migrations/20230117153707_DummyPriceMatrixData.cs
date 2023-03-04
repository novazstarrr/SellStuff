using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DummyPriceMatrixData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DECLARE @iPhone6TypeId TINYINT = 1;
DECLARE @iPhone6sTypeId TINYINT = 2;
DECLARE @iPhone7TypeId TINYINT = 3;
DECLARE @iPhone7PlusTypeId TINYINT = 4;
DECLARE @iPhone8TypeId TINYINT = 5;
DECLARE @iPhone8PlusTypeId TINYINT = 6;
DECLARE @iPhoneXTypeId TINYINT = 7;
DECLARE @iPadAir2TypeId TINYINT = 8;
DECLARE @16gbId TINYINT = 1;
DECLARE @32gbId TINYINT = 2;
DECLARE @64gbId TINYINT = 3;
DECLARE @128gbId TINYINT = 4;
DECLARE @256gbId TINYINT = 5;
DECLARE @GradeAId TINYINT = 1;
DECLARE @GradeBId TINYINT = 2;
DECLARE @GradeCId TINYINT = 3;

INSERT INTO dbo.PricingMatrix
(ModelId, MemorySizeId, GradeId, Price)
VALUES
(@iPhone6TypeId, @16gbId, @GradeAId, '80'),
(@iPhone6TypeId, @16gbId, @GradeBId, '70'),
(@iPhone6TypeId, @16gbId, @GradeCId, '60'),
(@iPhone6TypeId, @32gbId, @GradeAId, '90'),
(@iPhone6TypeId, @32gbId, @GradeBId, '80'),
(@iPhone6TypeId, @32gbId, @GradeCId, '70'),
(@iPhone6TypeId, @64gbId, @GradeAId, '100'),
(@iPhone6TypeId, @64gbId, @GradeBId, '90'),
(@iPhone6TypeId, @64gbId, @GradeCId, '80'),
(@iPhone6sTypeId, @16gbId, @GradeAId, '120'),
(@iPhone6sTypeId, @16gbId, @GradeBId, '110'),
(@iPhone6sTypeId, @16gbId, @GradeCId, '100'),
(@iPhone6sTypeId, @32gbId, @GradeAId, '130'),
(@iPhone6sTypeId, @32gbId, @GradeBId, '120'),
(@iPhone6sTypeId, @32gbId, @GradeCId, '110'),
(@iPhone6sTypeId, @64gbId, @GradeAId, '140'),
(@iPhone6sTypeId, @64gbId, @GradeBId, '130'),
(@iPhone6sTypeId, @64gbId, @GradeCId, '120'),
(@iPhone6sTypeId, @128gbId, @GradeAId, '150'),
(@iPhone6sTypeId, @128gbId, @GradeBId, '140'),
(@iPhone6sTypeId, @128gbId, @GradeCId, '130'),
(@iPhone7TypeId, @32gbId, @GradeAId, '170'),
(@iPhone7TypeId, @32gbId, @GradeBId, '160'),
(@iPhone7TypeId, @32gbId, @GradeCId, '150'),
(@iPhone7TypeId, @128gbId, @GradeAId, '180'),
(@iPhone7TypeId, @128gbId, @GradeBId, '170'),
(@iPhone7TypeId, @128gbId, @GradeCId, '160'),
(@iPhone7TypeId, @256gbId, @GradeAId, '190'),
(@iPhone7TypeId, @256gbId, @GradeBId, '180'),
(@iPhone7TypeId, @256gbId, @GradeCId, '170'),
(@iPhone7PlusTypeId, @32gbId, @GradeAId, '210'),
(@iPhone7PlusTypeId, @32gbId, @GradeBId, '200'),
(@iPhone7PlusTypeId, @32gbId, @GradeCId, '190'),
(@iPhone7PlusTypeId, @128gbId, @GradeAId, '220'),
(@iPhone7PlusTypeId, @128gbId, @GradeBId, '210'),
(@iPhone7PlusTypeId, @128gbId, @GradeCId, '200'),
(@iPhone7PlusTypeId, @256gbId, @GradeAId, '250'),
(@iPhone7PlusTypeId, @256gbId, @GradeBId, '240'),
(@iPhone7PlusTypeId, @256gbId, @GradeCId, '230');




            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM dbo.PricingMatrix;
                            ");
        }
    }
}
