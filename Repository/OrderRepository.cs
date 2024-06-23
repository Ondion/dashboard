using FullApp.DTO;
using FullApp.Models;

namespace FullApp.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly IDataBaseContext _context;

    public OrderRepository(IDataBaseContext context) // Injeta o contexto do banco de dados
    {
        this._context = context;
    }

    public DashboardMetricsDTO GetDashboardMetrics(DateTime date)
    {
        //  métricas de pedidos, pedidos abertos, valor total de pedidos abertos, pedidos abertos e fechados no mês, receita mensal, comissões e produtos vendidos no mês

        var OpenOrders = this._context.Pedidos.Count(p => p.StatusPedido == "aberto");

        var TotalValueOpenOrders = this._context.Pedidos
            .Where(p => p.StatusPedido == "aberto")
            .Sum(p => p.ValorBruto);

        var TotalOpenOrdersMonth = this._context.Pedidos
            .Count(p => p.StatusPedido == "aberto" && p.DataPedido.Month == date.Month && p.DataPedido.Year == date.Year);

        var TotalClosedOrdersMonth = this._context.Pedidos
            .Count(p => p.StatusPedido == "fechado" && p.DataPedido.Month == date.Month && p.DataPedido.Year == date.Year);

        var TotalMonthlyRevenueMonth = this._context.Pedidos
            .Where(p => p.DataPedido.Month == date.Month && p.DataPedido.Year == date.Year)
            .Where(p => p.StatusPedido == "fechado")
            .Sum(p => p.ValorBruto);

        var TotalCommissionsMonth = this._context.Pedidos
            .Where(p => p.DataPedido.Month == date.Month && p.DataPedido.Year == date.Year)
            .Where(p => p.StatusPedido == "fechado")
            .Sum(p => p.TotalComissao);

            var TotalProductsSoldMonth = this._context.PedidoProdutos
            .Where(p => p.Pedido!.DataPedido.Year == date.Year && p.Pedido.DataPedido.Month == date.Month)
            .Sum(p => p.Quantidade);

        return new DashboardMetricsDTO // Objeto de transferência 
        {
            OpenOrders = OpenOrders,
            TotalValueOpenOrders = TotalValueOpenOrders,
            TotalOpenOrdersMonth = TotalOpenOrdersMonth,
            TotalClosedOrdersMonth = TotalClosedOrdersMonth,
            TotalMonthlyRevenueMonth = TotalMonthlyRevenueMonth,
            TotalCommissionsMonth = TotalCommissionsMonth,
            TotalProductsSoldMonth = TotalProductsSoldMonth
        };
    }

    public ICollection<Pedido> GetOrders(int quantity)
    {
        return this._context.Pedidos
            .OrderByDescending(p => p.DataPedido)
            .Take(quantity)
            .ToList();
    }
}
