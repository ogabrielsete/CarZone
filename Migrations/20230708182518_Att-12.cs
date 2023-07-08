using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class prapagar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_MarcaId",
                table: "Venda",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Marcas_MarcaId",
                table: "Venda",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Marcas_MarcaId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_MarcaId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Venda");
        }
    }
}
