using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderNotificatorService.Models
{
    [Table("DSR_DokumentySprzedazyRachunki")]
    public class PosOrder
    {
        [Key]
        public long Id { get; set; }
        public int Number { get; set; }
        public required Table Table { get; set; }
        public int? TableId { get; set; }    
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public string? Description { get; set; }
        public required IList<PosOrderItem> PosOrderItems { get; set; }
    }
}
