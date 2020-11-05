using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AllpiFleetChauffeur : Migration
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
                    TypeRijbewijs = table.Column<string>(nullable: true),
                    Actief = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chauffeur", x => x.ChauffeurId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chauffeur");
        }
    }
}
