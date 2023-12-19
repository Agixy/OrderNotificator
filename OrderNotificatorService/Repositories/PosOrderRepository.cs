using Microsoft.EntityFrameworkCore;
using OrderNotificatorService.Interfaces;
using OrderNotificatorService.Models;

namespace OrderNotificatorService.Repositories
{
    public class PosOrderRepository : IOrderRepository
    {
        private readonly PosOrderDbContext _context;

        public PosOrderRepository(PosOrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PosOrder>> GetOpenOrders(long lastId = 0)
        {
            return await _context.PosOrders.Where(b => b.CloseDate == null && b.Id > lastId)
                .Include(n => n.Table).Include(n => n.PosOrderItems).ThenInclude(p => p.MenuItem).ToListAsync();
        }

        public async Task<IEnumerable<int>> GetMenuItemIdsByCategory(int categoryId)
        {
            return await _context.MenuItemCategories.Where(m => m.CategoryId == categoryId).Select(m => m.MenuItemId). ToListAsync();
        }
    }
}
