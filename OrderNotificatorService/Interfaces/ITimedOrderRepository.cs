﻿using OrderNotificatorService.Models;

namespace OrderNotificatorService.Interfaces
{
    public interface ITimedOrderRepository
    {
        public Task<IEnumerable<TimedOrder>> Get();
    }
}
