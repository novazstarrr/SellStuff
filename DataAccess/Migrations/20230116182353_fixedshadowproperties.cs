using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixedshadowproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypes_Brands_BrandId1",
                table: "DeviceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_DeviceTypes_DeviceTypeId1",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_DeviceTypeId1",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_DeviceTypes_BrandId1",
                table: "DeviceTypes");

            migrationBuilder.DropColumn(
                name: "DeviceTypeId1",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "BrandId1",
                table: "DeviceTypes");

            migrationBuilder.AlterColumn<byte>(
                name: "DeviceTypeId",
                table: "Models",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<byte>(
                name: "BrandId",
                table: "DeviceTypes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateIndex(
                name: "IX_Models_DeviceTypeId",
                table: "Models",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_BrandId",
                table: "DeviceTypes",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_Brands_BrandId",
                table: "DeviceTypes",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_DeviceTypes_DeviceTypeId",
                table: "Models",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypes_Brands_BrandId",
                table: "DeviceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_DeviceTypes_DeviceTypeId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_DeviceTypeId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_DeviceTypes_BrandId",
                table: "DeviceTypes");

            migrationBuilder.AlterColumn<short>(
                name: "DeviceTypeId",
                table: "Models",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "DeviceTypeId1",
                table: "Models",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<short>(
                name: "BrandId",
                table: "DeviceTypes",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "BrandId1",
                table: "DeviceTypes",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Models_DeviceTypeId1",
                table: "Models",
                column: "DeviceTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_BrandId1",
                table: "DeviceTypes",
                column: "BrandId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_Brands_BrandId1",
                table: "DeviceTypes",
                column: "BrandId1",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_DeviceTypes_DeviceTypeId1",
                table: "Models",
                column: "DeviceTypeId1",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
