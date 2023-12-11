using Microsoft.AspNetCore.Mvc;
using OrderNotificatorService.Interfaces;
using System.Linq;

namespace OrderNotificator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly INotificatorService orderNotificatorService;

        public OrderController(INotificatorService orderNotificatorService)
        {           
            this.orderNotificatorService = orderNotificatorService;
        }

        [HttpGet]
        [Route("[controller]/Kitchen")]
        public JsonResult GetKitchenOrders(int lastId)
        {        
            return new JsonResult(orderNotificatorService.GetKitchenOrders(lastId).Result.ToList());
        }

        [HttpGet]
        [Route("[controller]/Pizza")]
        public JsonResult GetPizzaOrders(int lastId)
        {
            return new JsonResult(orderNotificatorService.GetPizzaOrders(lastId).Result.ToList()); ;
        }
    }
}
