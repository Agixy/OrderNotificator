using Microsoft.EntityFrameworkCore;
using OrderNotificatorService.Interfaces;
using OrderNotificatorService.Models;

namespace OrderNotificatorService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOpenOrders()
        {
            return await _context.Orders.Where(b => b.CloseDate == null)
                .Include(n => n.Table)
                .Include(n => n.Waiter).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetNewOrders(int lastId)
        {
            return await _context.Orders.Where(b => b.CloseDate == null && b.Id > lastId)
                .Include(n => n.Table)
                .Include(n => n.Waiter).ToListAsync();
        }
    }
}
