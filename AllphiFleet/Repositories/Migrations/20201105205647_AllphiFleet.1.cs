using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AllphiFleet1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chauffeur",
                columns: table => new
                {
                    ChauffeurId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(nullable: false),
                    Adres = table.Column<string>(nullable: false),
                    GeboorteDatum = table.Column<DateTime>(nullable: false),
                    RijksRegisterNummer = table.Column<string>(nullable: false),
                    TypeRijbewijs = table.Column<int>(nullable: false),
                    Actief = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chauffeur", x => x.ChauffeurId);
                });

            migrationBuilder.InsertData(
                table: "chauffeur",
                columns: new[] { "ChauffeurId", "Actief", "Adres", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 1L, true, "Bremptstraat 54", new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "999-888-7777", 2, "Uncle" });

            migrationBuilder.InsertData(
                table: "chauffeur",
                columns: new[] { "ChauffeurId", "Actief", "Adres", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 2L, true, "Bremptstraat 54", new DateTime(1989, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breem", "999-888-1111", 1, "Rik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chauffeur");
        }
    }
}
