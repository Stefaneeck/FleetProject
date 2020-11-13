using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class allphidb13nov7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aanvraag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumAanvraag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeAanvraag = table.Column<int>(type: "int", nullable: false),
                    GewensteData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusAanvraag = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Aanvraag_VoertuigId",
                table: "Aanvraag",
                column: "VoertuigId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aanvraag");
        }
    }
}
