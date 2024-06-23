using FullApp.DTO;
using FullApp.Models;
using FullApp.Repository;

namespace FullApp.Services;


public class OrderService : IOrderService // Definição da classe que estende sua interface
{
    private readonly IOrderRepository? _repository;

    public OrderService(IOrderRepository repository) // Construtor que injeta o repositório de pedidos
    {
        this._repository = repository;
    }
    public DashboardMetricsDTO GetDashboardMetrics(DateTime date)
    {
        DashboardMetricsDTO data = this._repository!.GetDashboardMetrics(date);
        return data;
    }

    public ICollection<Pedido> GetOrders(int quantity)
    {
        ICollection<Pedido> data = this._repository!.GetOrders(quantity);
        return data;
    }
}