using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class TranslateToEnglish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aanvraag");

            migrationBuilder.DropTable(
                name: "Chauffeurs");

            migrationBuilder.DropTable(
                name: "Herstelling");

            migrationBuilder.DropTable(
                name: "Nummerplaat");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Tankkaarten");

            migrationBuilder.DropTable(
                name: "VerzekeringsMaatschappij");

            migrationBuilder.DropTable(
                name: "Factuur");

            migrationBuilder.DropTable(
                name: "Voertuig");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GivenName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    ValidUntilDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    AuthType = table.Column<int>(type: "int", nullable: false),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompany",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNrInsuranceCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassisNr = table.Column<long>(type: "bigint", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SocSecNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLicenseType = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    FuelCardId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_FuelCards_FuelCardId",
                        column: x => x.FuelCardId,
                        principalTable: "FuelCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repair",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DamageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documents = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repair", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repair_InsuranceCompany_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "InsuranceCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationType = table.Column<int>(type: "int", nullable: false),
                    PossibleDates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicensePlate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlateCharacters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensePlate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicensePlate_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DealerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenance_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_VehicleId",
                table: "Application",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AddressId",
                table: "Drivers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_FuelCardId",
                table: "Drivers",
                column: "FuelCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LicensePlate_VehicleId",
                table: "LicensePlate",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_InvoiceId",
                table: "Maintenance",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_VehicleId",
                table: "Maintenance",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repair_InsuranceCompanyId",
                table: "Repair",
                column: "InsuranceCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "LicensePlate");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Repair");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "FuelCards");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "InsuranceCompany");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GivenName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    AuthType = table.Column<int>(type: "int", nullable: false),
                    GeldigheidsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kaartnummer = table.Column<int>(type: "int", nullable: false),
                    Opties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tankkaarten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerzekeringsMaatschappij",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferentieNrVerzekeringsMaatschappij = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerzekeringsMaatschappij", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voertuig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassisNr = table.Column<long>(type: "bigint", nullable: false),
                    KilometerStand = table.Column<int>(type: "int", nullable: false),
                    TypeBrandStof = table.Column<int>(type: "int", nullable: false),
                    TypeWagen = table.Column<int>(type: "int", nullable: false)
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
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    AdresId = table.Column<long>(type: "bigint", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RijksRegisterNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TankkaartId = table.Column<long>(type: "bigint", nullable: false),
                    TypeRijbewijs = table.Column<int>(type: "int", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Herstelling",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumHerstelling = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Documenten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchadeOmschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerzekeringsMaatschappijId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herstelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Herstelling_VerzekeringsMaatschappij_VerzekeringsMaatschappijId",
                        column: x => x.VerzekeringsMaatschappijId,
                        principalTable: "VerzekeringsMaatschappij",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aanvraag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumAanvraag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GewensteData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusAanvraag = table.Column<int>(type: "int", nullable: false),
                    TypeAanvraag = table.Column<int>(type: "int", nullable: false),
                    VoertuigId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanvraag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aanvraag_Voertuig_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuig",
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
                    FactuurId = table.Column<long>(type: "bigint", nullable: false),
                    Garage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Chauffeurs",
                columns: new[] { "Id", "Actief", "AdresId", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TankkaartId", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 1L, true, 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "999-888-7777", 1L, 2, "Uncle" });

            migrationBuilder.InsertData(
                table: "Chauffeurs",
                columns: new[] { "Id", "Actief", "AdresId", "GeboorteDatum", "Naam", "RijksRegisterNummer", "TankkaartId", "TypeRijbewijs", "Voornaam" },
                values: new object[] { 2L, true, 2L, new DateTime(1989, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breem", "999-888-1111", 2L, 1, "Rik" });

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_VoertuigId",
                table: "Aanvraag",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_AdresId",
                table: "Chauffeurs",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeurs_TankkaartId",
                table: "Chauffeurs",
                column: "TankkaartId");

            migrationBuilder.CreateIndex(
                name: "IX_Herstelling_VerzekeringsMaatschappijId",
                table: "Herstelling",
                column: "VerzekeringsMaatschappijId");

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
    }
}
