using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class allphidb16nov3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chauffeurs",
                columns: new[] { "Id", "Actief", "AdresId", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TankkaartId", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 1L, true, 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "999-888-7777", 1L, 2, "Uncle" });

            migrationBuilder.InsertData(
                table: "Chauffeurs",
                columns: new[] { "Id", "Actief", "AdresId", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TankkaartId", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 2L, true, 2L, new DateTime(1989, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breem", "999-888-1111", 2L, 1, "Rik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chauffeurs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Chauffeurs",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
