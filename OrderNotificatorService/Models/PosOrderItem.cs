using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderNotificatorService.Models
{
    public class PosOrderItem
    {
        public long Id { get; set; }
        public required MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }
        public DateTime? CancellationDate { get; set; }

        [ForeignKey("PosOrderId")]
        public required PosOrder PosOrder { get; set; }
        public long PosOrderId { get; set; }
    }
}
