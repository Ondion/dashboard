
using Microsoft.AspNetCore.Mvc; // Namespaces necessários para a definição do controlador
using FullApp.Services;
using FullApp.Models;
using FullApp.DTO;


namespace FullApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        protected readonly IOrderService _service; // Inversão de dependência 

        public OrderController(IOrderService service)
        {
            this._service = service; // injeção de instância do serviço de pedidos
        }


        [HttpGet]
        public IActionResult GetDashboardMetrics([FromQuery] DateTime time)
        {
            try // Chama o serviço de pedidos para obter métricas da dashboard com base na data
            {
                DashboardMetricsDTO metrics = this._service.GetDashboardMetrics(time);
                return Ok(metrics);
            } // Captura de erro genérico
            catch (Exception error) { return StatusCode(500, error.Message); }
        }

        [HttpGet("{quantity}")]
        public IActionResult GePedidos(int quantity)
        {
            try // Chama o serviço de pedidos para obter coleção de pedidos limitada a quantidade fornecida
            {
                ICollection<Pedido> orders = this._service.GetOrders(quantity);
                return Ok(orders);
            } // Captura de erro genérico
            catch (Exception error) { return StatusCode(500, error.Message); }
        }
    }
}
