using Microsoft.AspNetCore.Mvc;
using OrderNotificatorService.Interfaces;
using OrderNotificatorService.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using static System.Net.WebRequestMethods;

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
            //var orders = orderRepository.GetOpenOrders().Result.ToList();

            var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Number = 101,
                    Table = new Table { Id = 1, Name = "Table 1" },
                    TableId = 1,
                    Waiter = new Waiter { Id = 1, Name = "John", Surname = "Doe" },
                    WaiterId = 1,
                    OpenDate = DateTime.Now,
                    CloseDate = null,
                    LastServiceDate = DateTime.Now.AddMinutes(30),
                    Description = "Order for lunch"
                },
                new Order
                {
                    Id = 2,
                    Number = 102,
                    Table = new Table { Id = 2, Name = "Table 2" },
                    TableId = 2,
                    Waiter = new Waiter { Id = 2, Name = "Jane", Surname = "Smith" },
                    WaiterId = 2,
                    OpenDate = DateTime.Now.AddDays(1),
                    CloseDate = null,
                    LastServiceDate = null,
                    Description = "Order for dinner"
                },
                new Order
                {
                    Id = 3,
                    Number = 103,
                    Table = new Table { Id = 3, Name = "Table 3" },
                    TableId = 3,
                    Waiter = new Waiter { Id = 3, Name = "Bob", Surname = "Johnson" },
                    WaiterId = 3,
                    OpenDate = DateTime.Now.AddHours(3),
                    CloseDate = null,
                    LastServiceDate = DateTime.Now.AddHours(3).AddMinutes(45),
                    Description = "Order for a party"
                },
                new Order
                {
                    Id = 4,
                    Number = 104,
                    Table = new Table { Id = 4, Name = "Table 4" },
                    TableId = 4,
                    Waiter = new Waiter { Id = 4, Name = "Alice", Surname = "Williams" },
                    WaiterId = 4,
                    OpenDate = DateTime.Now.AddDays(2),
                    CloseDate = null,
                    LastServiceDate = null,
                    Description = "Order for breakfast"
                },
                new Order
                {
                    Id = 5,
                    Number = 105,
                    Table = new Table { Id = 5, Name = "Table 5" },
                    TableId = 5,
                    Waiter = new Waiter { Id = 5, Name = "Charlie", Surname = "Brown" },
                    WaiterId = 5,
                    OpenDate = DateTime.Now.AddHours(5),
                    CloseDate = null,
                    LastServiceDate = null,
                    Description = "Order for lunch"
                },
                new Order
                {
                    Id = 6,
                    Number = 106,
                    Table = new Table { Id = 6, Name = "Table 6" },
                    TableId = 6,
                    Waiter = new Waiter { Id = 6, Name = "Eva", Surname = "Miller" },
                    WaiterId = 6,
                    OpenDate = DateTime.Now.AddDays(3),
                    CloseDate = null,
                    LastServiceDate = DateTime.Now.AddDays(3).AddHours(1).AddMinutes(45),
                    Description = "Order for dinner"
                },
                new Order
                {
                    Id = 7,
                    Number = 107,
                    Table = new Table { Id = 7, Name = "Table 7" },
                    TableId = 7,
                    Waiter = new Waiter { Id = 7, Name = "David", Surname = "Jones" },
                    WaiterId = 7,
                    OpenDate = DateTime.Now.AddHours(6),
                    CloseDate = null,
                    LastServiceDate = null,
                    Description = "Order for a meeting"
                }
            };


            return new JsonResult(orders);
        }

        [HttpPost]
        public JsonResult GetNewOrders(int lastId)
        {
            //var orders = orderRepository.GetNewOrders(lastId).Result.ToList();

            var orders = new List<Order>
            {
                new Order
                {
                    Id = 144,
                    Number = 101,
                    Table = new Table { Id = 1, Name = "Table 133" },
                    TableId = 1,
                    Waiter = new Waiter { Id = 1, Name = "John", Surname = "Doe" },
                    WaiterId = 1,
                    OpenDate = DateTime.Now,
                    CloseDate = null,
                    LastServiceDate = DateTime.Now.AddMinutes(30),
                    Description = "Order for lunch"
                },
                new Order
                {
                    Id = 244,
                    Number = 102,
                    Table = new Table { Id = 2, Name = "Table 233" },
                    TableId = 2,
                    Waiter = new Waiter { Id = 2, Name = "Jane", Surname = "Smith" },
                    WaiterId = 2,
                    OpenDate = DateTime.Now.AddDays(1),
                    CloseDate = null,
                    LastServiceDate = null,
                    Description = "Order for dinner"
                },
                new Order
                {
                    Id = 344,
                    Number = 103,
                    Table = new Table { Id = 3, Name = "Table 4443" },
                    TableId = 3,
                    Waiter = new Waiter { Id = 3, Name = "Bob", Surname = "Johnson" },
                    WaiterId = 3,
                    OpenDate = DateTime.Now.AddHours(3),
                    CloseDate = null,
                    LastServiceDate = DateTime.Now.AddHours(3).AddMinutes(45),
                    Description = "Order for a party"
                }
            };

            return new JsonResult(orders);
        }
    }
}
