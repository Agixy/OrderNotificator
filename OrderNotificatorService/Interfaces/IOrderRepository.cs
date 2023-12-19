using OrderNotificatorService.Models;

namespace OrderNotificatorService.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<PosOrder>> GetOpenOrders(long lastId);

        public Task<IEnumerable<int>> GetMenuItemIdsByCategory(int categoryId);
    }
}
