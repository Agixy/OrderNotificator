﻿using Microsoft.AspNetCore.Mvc;
using OrderNotificatorService.Dtos;
using OrderNotificatorService.Interfaces;
using System;
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
        public JsonResult GetKitchenOrders(long lastId)
        {
             return new JsonResult(orderNotificatorService.GetKitchenOrders(lastId).Result.ToList());
        }

        [HttpGet]
        [Route("Pizza/{lastId}")]
        public JsonResult GetPizzaOrders(long lastId)
        {
            return new JsonResult(orderNotificatorService.GetPizzaOrders(lastId).Result.ToList()); ;
        }

        [HttpGet]
        [Route("TimedOrders")]
        public JsonResult GetTimedOrders()
        {
            return new JsonResult(orderNotificatorService.GetTimedOrders().Result);
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
