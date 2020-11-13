using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class allphidb13nov6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Herstelling",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumHerstelling = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchadeOmschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerzekeringsMaatschappijId = table.Column<long>(type: "bigint", nullable: false),
                    Fotos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documenten = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Herstelling_VerzekeringsMaatschappijId",
                table: "Herstelling",
                column: "VerzekeringsMaatschappijId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Herstelling");

            migrationBuilder.DropTable(
                name: "VerzekeringsMaatschappij");
        }
    }
}
