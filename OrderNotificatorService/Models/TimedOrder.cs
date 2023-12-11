using System.ComponentModel.DataAnnotations.Schema;

namespace OrderNotificatorService.Models
{
    [Table("Orders")]
    public class TimedOrder
    {
        public long Id { get; set; }
        public required long PosId { get; set; }
        public required int Number { get; set; }
        public string TableName { get; set; }
        public required DateTime DeliveryTime { get; set; }
        public bool ContainOnlyPizza { get; set; }
    }
}
