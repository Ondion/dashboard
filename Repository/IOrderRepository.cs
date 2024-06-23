namespace FullApp.Repository;
using FullApp.DTO;
using FullApp.Models;

public interface IOrderRepository
{
    DashboardMetricsDTO GetDashboardMetrics(DateTime date);
    ICollection<Pedido> GetOrders(int quantity);
}

