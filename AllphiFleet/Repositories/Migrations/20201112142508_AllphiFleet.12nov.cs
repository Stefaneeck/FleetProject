using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AllphiFleet12nov : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RijksRegisterNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeRijbewijs = table.Column<int>(type: "int", nullable: false),
                    Actief = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Chauffeurs",
                columns: new[] { "Id", "Actief", "Adres", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 1L, true, "Bremptstraat 54", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "999-888-7777", 2, "Uncle" });

            migrationBuilder.InsertData(
                table: "Chauffeurs",
                columns: new[] { "Id", "Actief", "Adres", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 2L, true, "Bremptstraat 54", new DateTime(1989, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breem", "999-888-1111", 1, "Rik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chauffeurs");
        }
    }
}
