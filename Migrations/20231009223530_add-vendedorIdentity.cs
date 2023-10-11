using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class addvendedorIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "VendedorId",
                table: "Venda",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VendedorId",
                table: "Venda",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_AspNetUsers_VendedorId",
                table: "Venda",
                column: "VendedorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_AspNetUsers_VendedorId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_VendedorId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "Venda");

           
        }
    }
}
