using FullApp.DTO;
using FullApp.Models;

namespace FullApp.Services;

public interface IOrderService
{
    DashboardMetricsDTO GetDashboardMetrics(DateTime date);
    ICollection<Pedido> GetOrders(int quantity);
}

