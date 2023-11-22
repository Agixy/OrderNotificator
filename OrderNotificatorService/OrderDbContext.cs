using Microsoft.EntityFrameworkCore;
using OrderNotificatorService.Models;

namespace OrderNotificatorService
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(b => b.Id).HasColumnName("DSR_ID");
            modelBuilder.Entity<Order>().Property(b => b.Number).HasColumnName("DSR_NrRachunku");
            modelBuilder.Entity<Order>().Property(b => b.TableId).HasColumnName("DSR_STOID");
            modelBuilder.Entity<Order>().Property(b => b.WaiterId).HasColumnName("DSR_OPRID");
            modelBuilder.Entity<Order>().Property(b => b.OpenDate).HasColumnName("DSR_DataOtwarcia");
            modelBuilder.Entity<Order>().Property(b => b.CloseDate).HasColumnName("DSR_DataZamkniecia");
            modelBuilder.Entity<Order>().Property(b => b.LastServiceDate).HasColumnName("DSR_DataOstatniejObslugi");
            modelBuilder.Entity<Order>().Property(b => b.Description).HasColumnName("DSR_Opis");

            modelBuilder.Entity<Table>().ToTable("STO_Stoliki");
            modelBuilder.Entity<Table>().Property(b => b.Id).HasColumnName("STO_ID");
            modelBuilder.Entity<Table>().Property(b => b.Name).HasColumnName("STO_Nazwa");

            modelBuilder.Entity<Waiter>().ToTable("OPR_Operatorzy");
            modelBuilder.Entity<Waiter>().Property(b => b.Id).HasColumnName("OPR_ID");
            modelBuilder.Entity<Waiter>().Property(b => b.Name).HasColumnName("OPR_Imie");
            modelBuilder.Entity<Waiter>().Property(b => b.Surname).HasColumnName("OPR_Nazwisko");            

            modelBuilder.Entity<Order>().HasOne(p => p.Waiter).WithMany();
            modelBuilder.Entity<Order>().HasOne(p => p.Table).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
