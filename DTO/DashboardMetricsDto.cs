namespace FullApp.DTO;
using FullApp.Models;

        public class DashboardMetricsDTO
    {
        public int OpenOrders { get; set; }
        public decimal TotalValueOpenOrders { get; set; }
        public int TotalOpenOrdersMonth { get; set; }
        public int TotalClosedOrdersMonth { get; set; }
        public decimal TotalMonthlyRevenueMonth { get; set; }
        public decimal TotalCommissionsMonth { get; set; }
        public int TotalProductsSoldMonth { get; set; }
    }


