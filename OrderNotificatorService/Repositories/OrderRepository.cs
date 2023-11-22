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

        //public async Task<IEnumerable<BillsItem>> GetBillItemsByBillNumber(int billNumber)
        //{
        //    var billId = _context.Bills.FirstOrDefault(b => b.Number == billNumber).Id;
        //    return await _context.BillsItems.Where(b => b.BillId == billId).Include(b => b.MenuItem).ToListAsync();
        //}
    }
}
