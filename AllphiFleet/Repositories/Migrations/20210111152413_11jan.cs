using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class _11jan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DriverId",
                table: "Application",
                type: "bigint",
                //manually set to true because conflict with existing records
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Application_DriverId",
                table: "Application",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Drivers_DriverId",
                table: "Application",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Drivers_DriverId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_DriverId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Application");
        }
    }
}
