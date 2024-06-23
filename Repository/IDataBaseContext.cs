using Microsoft.EntityFrameworkCore;
using FullApp.Models;

namespace FullApp.Repository;

public interface IDataBaseContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<PedidoProduto> PedidoProdutos { get; set; }
    public int SaveChanges();
}

