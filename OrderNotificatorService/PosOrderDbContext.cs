using Microsoft.EntityFrameworkCore;
using OrderNotificatorService.Models;

namespace OrderNotificatorService
{
    public class PosOrderDbContext : DbContext
    {
        public DbSet<PosOrder> PosOrders { get; set; }
        public DbSet<Table> Tables { get; set; }

        public PosOrderDbContext(DbContextOptions<PosOrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosOrder>().Property(b => b.Id).HasColumnName("DSR_ID");
            modelBuilder.Entity<PosOrder>().Property(b => b.Number).HasColumnName("DSR_NrRachunku");
            modelBuilder.Entity<PosOrder>().Property(b => b.TableId).HasColumnName("DSR_STOID");
            modelBuilder.Entity<PosOrder>().Property(b => b.OpenDate).HasColumnName("DSR_DataOtwarcia");
            modelBuilder.Entity<PosOrder>().Property(b => b.CloseDate).HasColumnName("DSR_DataZamkniecia");
            modelBuilder.Entity<PosOrder>().Property(b => b.LastServiceDate).HasColumnName("DSR_DataOstatniejObslugi");
            modelBuilder.Entity<PosOrder>().Property(b => b.Description).HasColumnName("DSR_Opis");

            modelBuilder.Entity<Table>().ToTable("STO_Stoliki");
            modelBuilder.Entity<Table>().Property(b => b.Id).HasColumnName("STO_ID");
            modelBuilder.Entity<Table>().Property(b => b.Name).HasColumnName("STO_Nazwa");        

            modelBuilder.Entity<PosOrder>().HasOne(p => p.Table).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
