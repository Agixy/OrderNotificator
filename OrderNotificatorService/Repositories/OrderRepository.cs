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

        public async Task<IEnumerable<PosOrder>> GetOpenOrders(long lastId = 0)
        {
            return await _context.PosOrders.Where(b => b.CloseDate == null && b.Id > lastId)
                .Include(n => n.Table).ToListAsync();
        }
    }
}
