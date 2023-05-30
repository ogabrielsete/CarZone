using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Att06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Cliente",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Cliente",
                type: "INT",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Cliente",
                type: "INT",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);
        }
    }
}
