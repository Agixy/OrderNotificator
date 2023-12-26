using OrderNotificatorService.Dtos;
using OrderNotificatorService.Models;

namespace OrderNotificatorService.Interfaces
{
    public interface INotificatorService
    {
        public Task<IEnumerable<OrderDto>> GetKitchenOrders(long lastId);

        public Task<IEnumerable<TimedOrder>> GetPizzaOrders(long lastId);

        public Task<IEnumerable<OrderDto>> GetTimedOrders();

        public Task SavePizzaDeliveryTime(OrderDto order);
    }
}
