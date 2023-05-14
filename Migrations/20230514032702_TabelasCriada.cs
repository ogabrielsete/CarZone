using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarZone.Migrations
{
    public partial class TabelasCriada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientesDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloVeiculosDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeModelo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloVeiculosDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PagamentosDB",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentosDB", x => x.PagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "VeiculosDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    StatusVenda = table.Column<bool>(type: "bit", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculosDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcasDB",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    ModeloVeiculosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasDB", x => x.MarcaId);
                    table.ForeignKey(
                        name: "FK_MarcasDB_ModeloVeiculosDB_ModeloVeiculosId",
                        column: x => x.ModeloVeiculosId,
                        principalTable: "ModeloVeiculosDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcasDB_VeiculosDB_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "VeiculosDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendasDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVenda = table.Column<int>(type: "int", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    VeiculosId = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendasDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendasDB_ClientesDB_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClientesDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendasDB_VeiculosDB_VeiculosId",
                        column: x => x.VeiculosId,
                        principalTable: "VeiculosDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarcasDB_ModeloVeiculosId",
                table: "MarcasDB",
                column: "ModeloVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcasDB_VeiculoId",
                table: "MarcasDB",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasDB_ClienteId",
                table: "VendasDB",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasDB_VeiculosId",
                table: "VendasDB",
                column: "VeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcasDB");

            migrationBuilder.DropTable(
                name: "PagamentosDB");

            migrationBuilder.DropTable(
                name: "VendasDB");

            migrationBuilder.DropTable(
                name: "ModeloVeiculosDB");

            migrationBuilder.DropTable(
                name: "ClientesDB");

            migrationBuilder.DropTable(
                name: "VeiculosDB");
        }
    }
}
