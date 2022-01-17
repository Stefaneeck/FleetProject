using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class PossibleDatesApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossibleDates",
                table: "Application");

            migrationBuilder.AddColumn<DateTime>(
                name: "PossibleDate1",
                table: "Application",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PossibleDate2",
                table: "Application",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossibleDate1",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "PossibleDate2",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "PossibleDates",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
