using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AllpiFleetChauffeur2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actief",
                table: "chauffeur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Actief",
                table: "chauffeur",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
