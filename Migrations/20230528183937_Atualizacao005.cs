using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class Atualizacao005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId1",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Pagamento_PagamentoId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId1",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_ClienteId1",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_VeiculoId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_VeiculoId1",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "VeiculoId1",
                table: "Venda");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VeiculoId",
                table: "Venda",
                column: "VeiculoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Pagamento_PagamentoId",
                table: "Venda",
                column: "PagamentoId",
                principalTable: "Pagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId",
                table: "Venda",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Pagamento_PagamentoId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Veiculos_VeiculoId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_VeiculoId",
                table: "Venda");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "Venda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeiculoId1",
                table: "Venda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId1",
                table: "Venda",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VeiculoId",
                table: "Venda",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VeiculoId1",
                table: "Venda",
                column: "VeiculoId1",
                unique: true,
                filter: "[VeiculoId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId1",
                table: "Venda",
                column: "ClienteId1",
                principalTable: "Cliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Pagamento_PagamentoId",
                table: "Venda",
                column: "PagamentoId",
                principalTable: "Pagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
