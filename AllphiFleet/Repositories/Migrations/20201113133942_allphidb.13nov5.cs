using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class allphidb13nov5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factuur",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NaamGefactureerde = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factuur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tankkaarten",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kaartnummer = table.Column<int>(type: "int", nullable: false),
                    GeldigheidsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    AuthType = table.Column<int>(type: "int", nullable: false),
                    Opties = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tankkaarten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voertuig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeBrandStof = table.Column<int>(type: "int", nullable: false),
                    TypeWagen = table.Column<int>(type: "int", nullable: false),
                    KilometerStand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chauffeurs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RijksRegisterNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeRijbewijs = table.Column<int>(type: "int", nullable: false),
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    AdresId = table.Column<long>(type: "bigint", nullable: false),
                    TankkaartId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chauffeurs_Adressen_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adressen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chauffeurs_Tankkaarten_TankkaartId",
                        column: x => x.TankkaartId,
                        principalTable: "Tankkaarten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nummerplaat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NummerPlaatTekens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoertuigId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nummerplaat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nummerplaat_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOnderhoud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Garage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactuurId = table.Column<long>(type: "bigint", nullable: false),
                    VoertuigId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Factuur_FactuurId",
                        column: x => x.FactuurId,
                        principalTable: "Factuur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_AdresId",
                table: "Chauffeurs",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_TankkaartId",
                table: "Chauffeurs",
                column: "TankkaartId");

            migrationBuilder.CreateIndex(
                name: "IX_Nummerplaat_VoertuigId",
                table: "Nummerplaat",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_FactuurId",
                table: "Onderhoud",
                column: "FactuurId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_VoertuigId",
                table: "Onderhoud",
                column: "VoertuigId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Nummerplaat");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Tankkaarten");

            migrationBuilder.DropTable(
                name: "Factuur");

            migrationBuilder.DropTable(
                name: "Voertuig");
        }
    }
}
