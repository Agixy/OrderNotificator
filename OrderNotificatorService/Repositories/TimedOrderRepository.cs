using Microsoft.EntityFrameworkCore;
using OrderNotificatorService.Interfaces;
using OrderNotificatorService.Models;

namespace OrderNotificatorService.Repositories
{
    public class TimedOrderRepository : ITimedOrderRepository
    {
        private readonly TimedOrderDbContext _context;

        public TimedOrderRepository(TimedOrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimedOrder>> Get()
        {
            return await _context.TimedOrders.ToListAsync();
        }

        public void SaveTimedOrder(TimedOrder order)
        {
            _context.TimedOrders.Add(order);
            _context.SaveChanges();
        }
    }
}
