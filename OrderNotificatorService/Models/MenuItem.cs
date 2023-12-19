using System.ComponentModel.DataAnnotations.Schema;

namespace OrderNotificatorService.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
