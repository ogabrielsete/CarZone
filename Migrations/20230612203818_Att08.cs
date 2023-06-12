using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Att08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meses",
                table: "Pagamento");

            migrationBuilder.AddColumn<int>(
                name: "Meses",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meses",
                table: "Venda");

            migrationBuilder.AddColumn<int>(
                name: "Meses",
                table: "Pagamento",
                type: "INT",
                maxLength: 3,
                nullable: false,
                defaultValue: 0);
        }
    }
}
