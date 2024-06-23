
using Microsoft.AspNetCore.Mvc;
using FullApp.Repository;
using FullApp.Models;
using FullApp.DTO;


namespace FullApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        protected readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            this._repository = repository;
        }


        [HttpGet]
        public IActionResult GetDashboardMetrics([FromQuery] DateTime time)
        {
            DashboardMetricsDTO metrics = this._repository.GetDashboardMetrics(time);
            return Ok(metrics);
        }

        [HttpGet("{quantity}")]
        public IActionResult GePedidos(int quantity)
        {
            ICollection<Pedido> orders = this._repository.GetOrders(quantity);
            return Ok(orders);
        }
    }


}