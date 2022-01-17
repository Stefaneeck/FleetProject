using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthApi.Migrations
{
    public partial class insertedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05a1f68a-d58c-47bc-9814-bad784e72ada", "bc30908f-0a38-40c2-a2c9-58d64dbcbea9", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d810c406-2472-484a-92d8-185bd490dbc6", "fcb79c04-6bce-4c91-885a-a3f2233c3d66", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05a1f68a-d58c-47bc-9814-bad784e72ada");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d810c406-2472-484a-92d8-185bd490dbc6");
        }
    }
}
