using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderNotificatorService.Dtos;
using OrderNotificatorService.Interfaces;
using OrderNotificatorService.Models;
using System;
using System.Collections.Generic;
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
        [Route("Kitchen/{lastId}")]
        public JsonResult GetKitchenOrders(int lastId)
        {
             return new JsonResult(orderNotificatorService.GetKitchenOrders(lastId).Result.ToList());
        }

        [HttpGet]
        [Route("Pizza/{lastId}")]
        public JsonResult GetPizzaOrders(int lastId)
        {
            return new JsonResult(orderNotificatorService.GetPizzaOrders(lastId).Result.ToList()); ;
        }

        [HttpPost]
        [Route("PizzaDeliveryTime")]
        public JsonResult AddPizzaDeliveryTime(OrderDto order)
        {
            try
            {
                orderNotificatorService.SavePizzaDeliveryTime(order);
                return new JsonResult("Data zapisana");
            }
            catch(Exception ex)
            {
                return new JsonResult($"Blad zapisu daty: {ex.Message}");
            }
            
        }
    }
}
