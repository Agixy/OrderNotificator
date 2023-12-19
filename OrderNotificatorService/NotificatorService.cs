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
                    var order = new OrderDto(posOrder.Id, posOrder.Number, posOrder.Table.Name);

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

        public async Task<IEnumerable<TimedOrder>> GetPizzaOrders(long lastId)
        {          
            return (await timedOrderRepository.Get());
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
                DeliveryTime = orderDto.DeliveryTime,
                ContainOnlyPizza = orderDto.OrderContent == OrderContent.PizzaOnly
            };
        }

        private void SetOrderContent(OrderDto order, PosOrder posOrder)
        {
            var itemsIds = posOrder.PosOrderItems.Select(p => p.MenuItem.Id).ToList();
            var menuItemsPizza = orderRepository.GetMenuItemIdsByCategory(pizzaCateogryId).Result;

            if (itemsIds.All(item => menuItemsPizza.Contains(item)))
            {
                order.OrderContent = OrderContent.PizzaOnly;
            }
            else if (itemsIds.All(item => menuItemsPizza.Except(new List<int> { item }).Any()))
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
