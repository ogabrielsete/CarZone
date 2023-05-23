using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class atualizacao002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pagamento",
                table: "Pagamento",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cliente",
                newName: "Nome");

            migrationBuilder.AlterColumn<int>(
                name: "Meses",
                table: "Pagamento",
                type: "INT",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pagamento",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "ModeloVeiculo",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Cliente",
                type: "INT",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Endereço",
                table: "Cliente",
                type: "VARCHAR(125)",
                maxLength: 125,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Cliente",
                type: "INT",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pagamento",
                newName: "Pagamento");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cliente",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Meses",
                table: "Pagamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Pagamento",
                table: "Pagamento",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "ModeloVeiculo",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Cliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Endereço",
                table: "Cliente",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(125)",
                oldMaxLength: 125);

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Cliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cliente",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(80)",
                oldMaxLength: 80);
        }
    }
}
