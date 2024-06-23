using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fullApp.Migrations
{
    /// <inheritdoc />
    public partial class up_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorBruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalComissao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusPedido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusProduto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PedidoProdutos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoID = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProdutos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PedidoProdutos_Pedidos_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProdutos_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "ID", "DataPedido", "NomeCliente", "NomeVendedor", "StatusPedido", "TotalComissao", "ValorBruto", "ValorLiquido" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fras-le S.A.", "joão", "fechado", 50.00m, 350.00m, 300.00m },
                    { 2, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sabó Indústria e Comércio de Autopeças Ltda", "pedro", "fechado", 50.00m, 440.00m, 390.00m },
                    { 3, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iochpe-Maxion S.A.", "carla", "aberto", 50.00m, 570.00m, 520.00m },
                    { 4, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Randon Implementos e Participações S.A.", "marcelo", "aberto", 150.00m, 2400.00m, 2250.00m },
                    { 5, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tupy S.A.", "gabriel", "aberto", 100.00m, 1000.00m, 900.00m },
                    { 6, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahle Metal Leve S.A.", "roberto", "aberto", 140.00m, 1400.00m, 1260.00m },
                    { 7, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magneti Marelli Cofap Fabricadora de Peças Ltda", "maria", "fechado", 50.00m, 800.00m, 750.00m },
                    { 8, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bosch Sistemas Automotivos Ltda", "jose", "fechado", 50.00m, 1100.00m, 1050.00m },
                    { 9, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dana Indústrias Ltda", "joana", "fechado", 50.00m, 900.00m, 850.00m },
                    { 10, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eaton Ltda", "antônio", "fechado", 50.00m, 600.00m, 550.00m },
                    { 11, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haldex do Brasil Ltda", "andréa", "fechado", 50.00m, 500.00m, 450.00m },
                    { 12, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wabco do Brasil Indústria e Comércio de Controles para Veículos Ltda", "juliana", "fechado", 50.00m, 750.00m, 700.00m }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ID", "NomeProduto", "StatusProduto", "ValorUnitario" },
                values: new object[,]
                {
                    { 1, "tirante da tampa de bagagem", "Disponível", 100.00m },
                    { 2, "batente da fechadura do estepe", "Disponível", 150.00m },
                    { 3, "botão do porta-malas do porta-malas", "Disponível", 20.00m },
                    { 4, "kit de capa p/ pedal", "Disponível", 25.00m },
                    { 5, "capa do telecomando c/ 2 botões", "Disponível", 10.00m },
                    { 6, "cilindro da porta - c/chave", "Disponível", 250.00m },
                    { 7, "bateria automotiva", "Disponível", 400.00m },
                    { 8, "bomba de combustível", "Disponível", 800.00m },
                    { 9, "pneu radial", "Disponível", 500.00m },
                    { 10, "radiador", "Disponível", 700.00m },
                    { 11, "parafuso de roda", "Disponível", 10.00m },
                    { 12, "astilha de freio", "Disponível", 150.00m },
                    { 13, "Filtro de Óleo", "Disponível", 30.00m },
                    { 14, "Velas de Ignição", "Disponível", 40.00m },
                    { 15, "Correia Dentada", "Disponível", 200.00m },
                    { 16, "Amortecedor", "Disponível", 300.00m },
                    { 17, "Filtro de Combustível", "Disponível", 50.00m },
                    { 18, "Farol", "Disponível", 250.00m },
                    { 19, "Retrovisor", "Disponível", 120.00m },
                    { 20, "Volante", "Disponível", 600.00m }
                });

            migrationBuilder.InsertData(
                table: "PedidoProdutos",
                columns: new[] { "ID", "PedidoID", "ProdutoID", "Quantidade", "ValorUnitario" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 100.00m },
                    { 2, 1, 2, 1, 150.00m },
                    { 3, 2, 1, 1, 100.00m },
                    { 4, 2, 2, 2, 150.00m },
                    { 5, 2, 3, 2, 20.00m },
                    { 6, 3, 4, 2, 25.00m },
                    { 7, 3, 5, 2, 10.00m },
                    { 8, 3, 6, 2, 250.00m },
                    { 9, 4, 7, 2, 400.00m },
                    { 10, 4, 8, 2, 800.00m },
                    { 11, 5, 9, 2, 500.00m },
                    { 12, 6, 10, 2, 700.00m },
                    { 13, 7, 11, 4, 10.00m },
                    { 14, 7, 12, 2, 150.00m },
                    { 15, 8, 13, 2, 30.00m },
                    { 16, 8, 14, 2, 40.00m },
                    { 17, 9, 15, 1, 200.00m },
                    { 18, 9, 16, 2, 300.00m },
                    { 19, 10, 17, 2, 50.00m },
                    { 20, 10, 18, 1, 250.00m },
                    { 21, 11, 19, 2, 120.00m },
                    { 22, 11, 20, 1, 600.00m },
                    { 23, 12, 1, 2, 100.00m },
                    { 24, 12, 2, 1, 150.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProdutos_PedidoID",
                table: "PedidoProdutos",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProdutos_ProdutoID",
                table: "PedidoProdutos",
                column: "ProdutoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProdutos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
