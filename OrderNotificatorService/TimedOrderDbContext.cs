using Microsoft.EntityFrameworkCore;
using OrderNotificatorService.Models;

namespace OrderNotificatorService
{
    public class TimedOrderDbContext : DbContext
    {
        public DbSet<TimedOrder> TimedOrders { get; set; }

        public TimedOrderDbContext(DbContextOptions<TimedOrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimedOrder>().Property(b => b.Id).HasColumnName("Id");
            modelBuilder.Entity<TimedOrder>().Property(b => b.PosId).HasColumnName("Pos_Id");
            modelBuilder.Entity<TimedOrder>().Property(b => b.Number).HasColumnName("Number");
            modelBuilder.Entity<TimedOrder>().Property(b => b.TableName).HasColumnName("Table_Name");
            modelBuilder.Entity<TimedOrder>().Property(b => b.DeliveryTime).HasColumnName("Delivery_Time");
            modelBuilder.Entity<TimedOrder>().Property(b => b.ContainOnlyPizza).HasColumnName("Contain_Only_Pizza");
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
