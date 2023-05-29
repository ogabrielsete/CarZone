using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Atualizacao008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId1",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_VeiculoId1",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "VeiculoId1",
                table: "Venda");

            migrationBuilder.RenameColumn(
                name: "VeiculoId",
                table: "Venda",
                newName: "ModeloId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_VeiculoId",
                table: "Venda",
                newName: "IX_Venda_ModeloId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_ModeloVeiculo_ModeloId",
                table: "Venda",
                column: "ModeloId",
                principalTable: "ModeloVeiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Venda_VendaId",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_ModeloVeiculo_ModeloId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_VendaId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "ModeloId",
                table: "Venda",
                newName: "VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ModeloId",
                table: "Venda",
                newName: "IX_Venda_VeiculoId");

            migrationBuilder.AddColumn<int>(
                name: "VeiculoId1",
                table: "Venda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VeiculoId1",
                table: "Venda",
                column: "VeiculoId1",
                unique: true,
                filter: "[VeiculoId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId",
                table: "Venda",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId1",
                table: "Venda",
                column: "VeiculoId1",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }
    }
}
