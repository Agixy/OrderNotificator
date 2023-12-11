using OrderNotificatorService.Models;

namespace OrderNotificatorService.Dtos
{
    public class OrderDto
    {
        public long PosId { get; set; }
        public int Number { get; set; }
        public string TableName { get; set; }
        public DateTime DeliveryTime { get; set; }
        public bool ContainOnlyPizza { get; set; }

        public OrderDto(long posId, int number)
        {
            PosId = posId;
            Number = number;
        }
    }
}
