using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class ActiveLicensePlateAndInvoiceChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Invoice_InvoiceId",
                table: "Maintenance");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Maintenance_InvoiceId",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Maintenance");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceDocumentPath",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "LicensePlate",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceDocumentPath",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "LicensePlate");

            migrationBuilder.AddColumn<long>(
                name: "InvoiceId",
                table: "Maintenance",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_InvoiceId",
                table: "Maintenance",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Invoice_InvoiceId",
                table: "Maintenance",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
