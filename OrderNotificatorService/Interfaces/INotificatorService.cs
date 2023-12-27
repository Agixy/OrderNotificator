using OrderNotificatorService.Dtos;

namespace OrderNotificatorService.Interfaces
{
    public interface INotificatorService
    {
        public Task<IEnumerable<OrderDto>> GetKitchenOrders(long lastId);

        public Task<IEnumerable<OrderDto>> GetPizzaOrders(long lastId);

        public Task<IEnumerable<OrderDto>> GetTimedOrders();

        public Task SavePizzaDeliveryTime(OrderDto order);
    }
}
