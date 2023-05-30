using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Att07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataVenda",
                table: "Venda",
                type: "datetime",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DataVenda",
                table: "Venda",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldMaxLength: 10);
        }
    }
}
