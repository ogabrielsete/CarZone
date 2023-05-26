using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Atualizacao002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pagamento",
                newName: "NomePagamento");

            migrationBuilder.AlterColumn<string>(
                name: "NomePagamento",
                table: "Pagamento",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomePagamento",
                table: "Pagamento",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pagamento",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldMaxLength: 100);
        }
    }
}
