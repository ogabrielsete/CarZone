using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Att11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteNome",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ModeloNome",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "PagamentoNome",
                table: "Venda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteNome",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModeloNome",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PagamentoNome",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
