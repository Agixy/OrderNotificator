using OrderNotificatorService.Dtos;
using OrderNotificatorService.Interfaces;
using OrderNotificatorService.Models;

namespace OrderNotificatorService
{
    public class NotificatorService : INotificatorService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ITimedOrderRepository timedOrderRepository;

        public NotificatorService(IOrderRepository orderRepository, ITimedOrderRepository pizzaOrderRepository)
        {
            this.orderRepository = orderRepository;
            this.timedOrderRepository = pizzaOrderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetKitchenOrders(long lastId)
        {
            var posOrders = await orderRepository.GetOpenOrders(lastId);

            var timedOrders = await timedOrderRepository.Get();

            var orders = new List<OrderDto>();

            foreach (var posOrder in posOrders)
            {
                var order = new OrderDto(posOrder.Id, posOrder.Number);

                if (timedOrders.Any(o => o.PosId == posOrder.Id))
                {
                    var timedOrder = timedOrders.First(to => to.PosId == order.PosId);
                    order.DeliveryTime = timedOrder.DeliveryTime;
                }

                orders.Add(order);
            }

            return orders;
        }

        public async Task<IEnumerable<TimedOrder>> GetPizzaOrders(long lastId)
        {          
            return (await timedOrderRepository.Get());
        }
    }
}
