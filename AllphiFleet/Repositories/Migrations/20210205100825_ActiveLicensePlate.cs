using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class ActiveLicensePlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ActiveLicensePlateId",
                table: "Vehicle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ActiveLicensePlateId1",
                table: "Vehicle",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ActiveLicensePlateId1",
                table: "Vehicle",
                column: "ActiveLicensePlateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_LicensePlate_ActiveLicensePlateId1",
                table: "Vehicle",
                column: "ActiveLicensePlateId1",
                principalTable: "LicensePlate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_LicensePlate_ActiveLicensePlateId1",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ActiveLicensePlateId1",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ActiveLicensePlateId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ActiveLicensePlateId1",
                table: "Vehicle");
        }
    }
}
