using OrderNotificatorService.Dtos;
using OrderNotificatorService.Enums;
using OrderNotificatorService.Interfaces;
using OrderNotificatorService.Models;

namespace OrderNotificatorService
{
    public class NotificatorService : INotificatorService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ITimedOrderRepository timedOrderRepository;
        private const int pizzaCateogryId = 5200192;
        private const int czekadelkoId = 5203957;

        public NotificatorService(IOrderRepository orderRepository, ITimedOrderRepository pizzaOrderRepository)
        {
            this.orderRepository = orderRepository;
            this.timedOrderRepository = pizzaOrderRepository;            
        }

        public async Task<IEnumerable<OrderDto>> GetKitchenOrders(long lastId)
        {
            var posOrders = await orderRepository.GetOpenOrders(lastId);
            var orders = new List<OrderDto>();

            if (posOrders.Count() > 0)
            {
                var timedOrders = await timedOrderRepository.Get();               

                foreach (var posOrder in posOrders)
                {
                    var order = new OrderDto(posOrder.Id, posOrder.Number, posOrder.Table?.Name);

                    SetOrderContent(order, posOrder);

                    if (timedOrders.Any(o => o.PosId == posOrder.Id))
                    {
                        var timedOrder = timedOrders.First(to => to.PosId == order.PosId);
                        order.DeliveryTime = timedOrder.DeliveryTime;
                    }

                    orders.Add(order);
                }
            }

            return orders;
        }

        public async Task<IEnumerable<OrderDto>> GetPizzaOrders(long lastId)
        {
            var posOrders = await orderRepository.GetOpenOrders(lastId);
            var orders = new List<OrderDto>();

            if (posOrders.Count() > 0)
            {
                var timedOrders = await timedOrderRepository.Get();

                foreach (var posOrder in posOrders)
                {
                    var order = new OrderDto(posOrder.Id, posOrder.Number, posOrder.Table?.Name);

                    SetOrderContent(order, posOrder);

                    if (order.OrderContent == OrderContent.DishesOnly)
                    {
                        continue;
                    }

                    if (timedOrders.Any(o => o.PosId == posOrder.Id))
                    {
                        var timedOrder = timedOrders.First(to => to.PosId == order.PosId);
                        order.DeliveryTime = timedOrder.DeliveryTime;
                    }

                    orders.Add(order);
                }
            }

            return orders;


           
        }

        public async Task<IEnumerable<OrderDto>> GetTimedOrders()
        {
            var timedOrders = await timedOrderRepository.Get();           
            return timedOrders.Select(t => ConvertTimedOrderToDto(t));
        }

        public async Task SavePizzaDeliveryTime(OrderDto order)
        {
            var timedOrder = ConvertDtoToTimedOrder(order);
            
            timedOrderRepository.SaveTimedOrder(timedOrder);
        }

        private TimedOrder ConvertDtoToTimedOrder(OrderDto orderDto)
        {            
            return new TimedOrder
            {
                Id = orderDto.TimedOrderId,
                PosId = orderDto.PosId,
                Number = orderDto.Number,
                TableName = orderDto.TableName,
                DeliveryTime = orderDto.DeliveryTime.ToLocalTime(),
                ContainOnlyPizza = orderDto.OrderContent == OrderContent.PizzaOnly
            };
        }

        private OrderDto ConvertTimedOrderToDto(TimedOrder timedOrder)
        {
            return new OrderDto(timedOrder.PosId, timedOrder.Number, timedOrder.TableName)
            {
                TimedOrderId = timedOrder.Id,
                DeliveryTime = timedOrder.DeliveryTime,
                OrderContent = timedOrder.ContainOnlyPizza ? OrderContent.PizzaOnly : OrderContent.PizzaAndDishes 
            };
        }

        private void SetOrderContent(OrderDto order, PosOrder posOrder)
        {
            var itemsIds = posOrder.PosOrderItems.Select(p => p.MenuItem.Id).ToList();
            var menuItemsPizza = orderRepository.GetMenuItemIdsByCategory(pizzaCateogryId).Result;

            

            if (itemsIds.All(item => menuItemsPizza.Contains(item) || item == czekadelkoId))
            {
                order.OrderContent = OrderContent.PizzaOnly;
            }
            else if (!itemsIds.Any(itemId => menuItemsPizza.Contains(itemId)))
            {
                order.OrderContent = OrderContent.DishesOnly;
            }
            else
            {
                order.OrderContent = OrderContent.PizzaAndDishes;
            }
        }
    }
}
