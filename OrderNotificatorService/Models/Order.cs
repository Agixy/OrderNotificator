using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderNotificatorService.Models
{
    [Table("DSR_DokumentySprzedazyRachunki")]
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public int Number { get; set; }
        public Table Table { get; set; }
        public int? TableId { get; set; }       
        public Waiter Waiter { get; set; }
        public int WaiterId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public string Description { get; set; }
    }
}
