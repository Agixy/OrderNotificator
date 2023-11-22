using Microsoft.AspNetCore.Mvc;
using OrderNotificatorService.Interfaces;
using System.Linq;

namespace OrderNotificator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {           
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var orders = orderRepository.GetOpenOrders().Result.ToList();

            return new JsonResult(orders);
        }
    }
}
