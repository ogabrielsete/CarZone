using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class att009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Venda_VendaId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_VendaId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Veiculos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_VendaId",
                table: "Veiculos",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Venda_VendaId",
                table: "Veiculos",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
