using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Atualizacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarcasDB_VeiculosDB_VeiculoId",
                table: "MarcasDB");

            migrationBuilder.DropIndex(
                name: "IX_MarcasDB_VeiculoId",
                table: "MarcasDB");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "MarcasDB");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculosDB_MarcaId",
                table: "VeiculosDB",
                column: "MarcaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculosDB_MarcasDB_MarcaId",
                table: "VeiculosDB",
                column: "MarcaId",
                principalTable: "MarcasDB",
                principalColumn: "MarcaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeiculosDB_MarcasDB_MarcaId",
                table: "VeiculosDB");

            migrationBuilder.DropIndex(
                name: "IX_VeiculosDB_MarcaId",
                table: "VeiculosDB");

            migrationBuilder.AddColumn<int>(
                name: "VeiculoId",
                table: "MarcasDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MarcasDB_VeiculoId",
                table: "MarcasDB",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarcasDB_VeiculosDB_VeiculoId",
                table: "MarcasDB",
                column: "VeiculoId",
                principalTable: "VeiculosDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
