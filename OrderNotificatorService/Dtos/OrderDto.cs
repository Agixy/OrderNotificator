using OrderNotificatorService.Enums;
using OrderNotificatorService.Models;

namespace OrderNotificatorService.Dtos
{
    public class OrderDto
    {
        public long PosId { get; set; }
        public long TimedOrderId { get; set; }
        public int Number { get; set; }
        public string TableName { get; set; }
        public DateTime DeliveryTime { get; set; }
        public OrderContent OrderContent { get; set; }

        public OrderDto(long posId, int number, string tableName)
        {
            PosId = posId;
            Number = number;
            TableName = tableName;
        }
    }
}
