using System.ComponentModel.DataAnnotations.Schema;

namespace OrderNotificatorService.Models
{
    [Table("AXK_ArtXKat")]
    public class MenuItemCategory
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }    
        public int CategoryId { get; set; }
    }
}
