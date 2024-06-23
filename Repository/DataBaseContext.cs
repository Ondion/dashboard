using Microsoft.EntityFrameworkCore;
using FullApp.Models;

namespace FullApp.Repository;


public class DataBaseContext : DbContext, IDataBaseContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<PedidoProduto> PedidoProdutos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = Environment.GetEnvironmentVariable("SQL_SERVER")!;
            optionsBuilder.UseSqlServer(connectionString);
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>()
         .HasMany(p => p.PedidoProduto)
         .WithOne(pi => pi.Pedido)
         .HasForeignKey(pi => pi.PedidoID);

        modelBuilder.Entity<Produto>()
            .HasMany(p => p.PedidoProduto)
            .WithOne(pi => pi.Produto)
            .HasForeignKey(pi => pi.ProdutoID);


        // Seed Produto
        modelBuilder.Entity<Produto>().HasData(
            new Produto { ID = 1, NomeProduto = "tirante da tampa de bagagem", ValorUnitario = 100.00m, StatusProduto = "Disponível" },
            new Produto { ID = 2, NomeProduto = "batente da fechadura do estepe", ValorUnitario = 150.00m, StatusProduto = "Disponível" },
            new Produto { ID = 3, NomeProduto = "botão do porta-malas do porta-malas", ValorUnitario = 20.00m, StatusProduto = "Disponível" },
            new Produto { ID = 4, NomeProduto = "kit de capa p/ pedal", ValorUnitario = 25.00m, StatusProduto = "Disponível" },
            new Produto { ID = 5, NomeProduto = "capa do telecomando c/ 2 botões", ValorUnitario = 10.00m, StatusProduto = "Disponível" },
            new Produto { ID = 6, NomeProduto = "cilindro da porta - c/chave", ValorUnitario = 250.00m, StatusProduto = "Disponível" },
            new Produto { ID = 7, NomeProduto = "bateria automotiva", ValorUnitario = 400.00m, StatusProduto = "Disponível" },
            new Produto { ID = 8, NomeProduto = "bomba de combustível", ValorUnitario = 800.00m, StatusProduto = "Disponível" },
            new Produto { ID = 9, NomeProduto = "pneu radial", ValorUnitario = 500.00m, StatusProduto = "Disponível" },
            new Produto { ID = 10, NomeProduto = "radiador", ValorUnitario = 700.00m, StatusProduto = "Disponível" },
            new Produto { ID = 11, NomeProduto = "parafuso de roda", ValorUnitario = 10.00m, StatusProduto = "Disponível" },
            new Produto { ID = 12, NomeProduto = "astilha de freio", ValorUnitario = 150.00m, StatusProduto = "Disponível" },
            new Produto { ID = 13, NomeProduto = "Filtro de Óleo", ValorUnitario = 30.00m, StatusProduto = "Disponível" },
            new Produto { ID = 14, NomeProduto = "Velas de Ignição", ValorUnitario = 40.00m, StatusProduto = "Disponível" },
            new Produto { ID = 15, NomeProduto = "Correia Dentada", ValorUnitario = 200.00m, StatusProduto = "Disponível" },
            new Produto { ID = 16, NomeProduto = "Amortecedor", ValorUnitario = 300.00m, StatusProduto = "Disponível" },
            new Produto { ID = 17, NomeProduto = "Filtro de Combustível", ValorUnitario = 50.00m, StatusProduto = "Disponível" },
            new Produto { ID = 18, NomeProduto = "Farol", ValorUnitario = 250.00m, StatusProduto = "Disponível" },
            new Produto { ID = 19, NomeProduto = "Retrovisor", ValorUnitario = 120.00m, StatusProduto = "Disponível" },
            new Produto { ID = 20, NomeProduto = "Volante", ValorUnitario = 600.00m, StatusProduto = "Disponível" }
        );

        // Seed Pedidos
        modelBuilder.Entity<Pedido>().HasData(
            new Pedido
            {
                ID = 1,
                NomeCliente = "Fras-le S.A.",
                NomeVendedor = "joão",
                ValorBruto = 350.00m,
                ValorLiquido = 300.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 6, 15),
                StatusPedido = "fechado"
            },
            new Pedido
            {
                ID = 2,
                NomeCliente = "Sabó Indústria e Comércio de Autopeças Ltda",
                NomeVendedor = "pedro",
                ValorBruto = 440.00m,
                ValorLiquido = 390.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 6, 15),
                StatusPedido = "fechado"
            },
            new Pedido
            {
                ID = 3,
                NomeCliente = "Iochpe-Maxion S.A.",
                NomeVendedor = "carla",
                ValorBruto = 570.00m,
                ValorLiquido = 520.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 6, 15),
                StatusPedido = "aberto"
            },
            new Pedido
            {
                ID = 4,
                NomeCliente = "Randon Implementos e Participações S.A.",
                NomeVendedor = "marcelo",
                ValorBruto = 2400.00m,
                ValorLiquido = 2250.00m,
                TotalComissao = 150.00m,
                DataPedido = new DateTime(2024, 6, 15),
                StatusPedido = "aberto"
            },
            new Pedido
            {
                ID = 5,
                NomeCliente = "Tupy S.A.",
                NomeVendedor = "gabriel",
                ValorBruto = 1000.00m,
                ValorLiquido = 900.00m,
                TotalComissao = 100.00m,
                DataPedido = new DateTime(2024, 6, 15),
                StatusPedido = "aberto"
            },
            new Pedido
            {
                ID = 6,
                NomeCliente = "Mahle Metal Leve S.A.",
                NomeVendedor = "roberto",
                ValorBruto = 1400.00m,
                ValorLiquido = 1260.00m,
                TotalComissao = 140.00m,
                DataPedido = new DateTime(2024, 6, 15),
                StatusPedido = "aberto"
            },
            new Pedido
            {
                ID = 7,
                NomeCliente = "Magneti Marelli Cofap Fabricadora de Peças Ltda",
                NomeVendedor = "maria",
                ValorBruto = 800.00m,
                ValorLiquido = 750.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 5, 15),
                StatusPedido = "fechado"
            },
            new Pedido
            {
                ID = 8,
                NomeCliente = "Bosch Sistemas Automotivos Ltda",
                NomeVendedor = "jose",
                ValorBruto = 1100.00m,
                ValorLiquido = 1050.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 4, 20),
                StatusPedido = "fechado"
            },
            new Pedido
            {
                ID = 9,
                NomeCliente = "Dana Indústrias Ltda",
                NomeVendedor = "joana",
                ValorBruto = 900.00m,
                ValorLiquido = 850.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 3, 10),
                StatusPedido = "fechado"
            },
            new Pedido
            {
                ID = 10,
                NomeCliente = "Eaton Ltda",
                NomeVendedor = "antônio",
                ValorBruto = 600.00m,
                ValorLiquido = 550.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 2, 25),
                StatusPedido = "fechado"
            },
            new Pedido
            {
                ID = 11,
                NomeCliente = "Haldex do Brasil Ltda",
                NomeVendedor = "andréa",
                ValorBruto = 500.00m,
                ValorLiquido = 450.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 1, 30),
                StatusPedido = "fechado"
            },
            new Pedido
            {
                ID = 12,
                NomeCliente = "Wabco do Brasil Indústria e Comércio de Controles para Veículos Ltda",
                NomeVendedor = "juliana",
                ValorBruto = 750.00m,
                ValorLiquido = 700.00m,
                TotalComissao = 50.00m,
                DataPedido = new DateTime(2024, 1, 30),
                StatusPedido = "fechado"
            }
        );


       modelBuilder.Entity<PedidoProduto>().HasData(
        new PedidoProduto { ID = 1, PedidoID = 1, ProdutoID = 1, Quantidade = 2, ValorUnitario = 100.00m },
        new PedidoProduto { ID = 2, PedidoID = 1, ProdutoID = 2, Quantidade = 1, ValorUnitario = 150.00m },
        new PedidoProduto { ID = 3, PedidoID = 2, ProdutoID = 1, Quantidade = 1, ValorUnitario = 100.00m },
        new PedidoProduto { ID = 4, PedidoID = 2, ProdutoID = 2, Quantidade = 2, ValorUnitario = 150.00m },
        new PedidoProduto { ID = 5, PedidoID = 2, ProdutoID = 3, Quantidade = 2, ValorUnitario = 20.00m },
        new PedidoProduto { ID = 6, PedidoID = 3, ProdutoID = 4, Quantidade = 2, ValorUnitario = 25.00m },
        new PedidoProduto { ID = 7, PedidoID = 3, ProdutoID = 5, Quantidade = 2, ValorUnitario = 10.00m },
        new PedidoProduto { ID = 8, PedidoID = 3, ProdutoID = 6, Quantidade = 2, ValorUnitario = 250.00m },
        new PedidoProduto { ID = 9, PedidoID = 4, ProdutoID = 7, Quantidade = 2, ValorUnitario = 400.00m },
        new PedidoProduto { ID = 10, PedidoID = 4, ProdutoID = 8, Quantidade = 2, ValorUnitario = 800.00m },
        new PedidoProduto { ID = 11, PedidoID = 5, ProdutoID = 9, Quantidade = 2, ValorUnitario = 500.00m },
        new PedidoProduto { ID = 12, PedidoID = 6, ProdutoID = 10, Quantidade = 2, ValorUnitario = 700.00m },
        new PedidoProduto { ID = 13, PedidoID = 7, ProdutoID = 11, Quantidade = 4, ValorUnitario = 10.00m },
        new PedidoProduto { ID = 14, PedidoID = 7, ProdutoID = 12, Quantidade = 2, ValorUnitario = 150.00m },
        new PedidoProduto { ID = 15, PedidoID = 8, ProdutoID = 13, Quantidade = 2, ValorUnitario = 30.00m },
        new PedidoProduto { ID = 16, PedidoID = 8, ProdutoID = 14, Quantidade = 2, ValorUnitario = 40.00m },
        new PedidoProduto { ID = 17, PedidoID = 9, ProdutoID = 15, Quantidade = 1, ValorUnitario = 200.00m },
        new PedidoProduto { ID = 18, PedidoID = 9, ProdutoID = 16, Quantidade = 2, ValorUnitario = 300.00m },
        new PedidoProduto { ID = 19, PedidoID = 10, ProdutoID = 17, Quantidade = 2, ValorUnitario = 50.00m },
        new PedidoProduto { ID = 20, PedidoID = 10, ProdutoID = 18, Quantidade = 1, ValorUnitario = 250.00m },
        new PedidoProduto { ID = 21, PedidoID = 11, ProdutoID = 19, Quantidade = 2, ValorUnitario = 120.00m },
        new PedidoProduto { ID = 22, PedidoID = 11, ProdutoID = 20, Quantidade = 1, ValorUnitario = 600.00m },
        new PedidoProduto { ID = 23, PedidoID = 12, ProdutoID = 1, Quantidade = 2, ValorUnitario = 100.00m },
        new PedidoProduto { ID = 24, PedidoID = 12, ProdutoID = 2, Quantidade = 1, ValorUnitario = 150.00m }
    );


    }
}

