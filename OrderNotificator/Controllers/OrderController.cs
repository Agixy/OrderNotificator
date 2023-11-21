using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace OrderNotificator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly DataTable Orders = new DataTable();

   

        public OrderController()
        {
            Orders.Columns.Add("OrderNumber", typeof(int));
        }

        [HttpGet]
        public JsonResult Get()
        {        
            Orders.Rows.Add(222);
            Orders.Rows.Add(333);
            Orders.Rows.Add(444);
            Orders.Rows.Add(555);
            Orders.Rows.Add(666);
            Orders.Rows.Add(777);
            Orders.Rows.Add(888);

            return new JsonResult(Orders);
        }

    }
}
