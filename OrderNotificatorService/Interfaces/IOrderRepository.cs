using OrderNotificatorService.Models;

namespace OrderNotificatorService.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<PosOrder>> GetOpenOrders(long lastId);
    }
}
