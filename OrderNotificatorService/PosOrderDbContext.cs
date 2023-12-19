using Microsoft.EntityFrameworkCore;
using OrderNotificatorService.Models;

namespace OrderNotificatorService
{
    public class PosOrderDbContext : DbContext
    {
        public DbSet<PosOrder> PosOrders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemCategory> MenuItemCategories { get; set; }

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

            modelBuilder.Entity<PosOrderItem>().ToTable("DSL_DokumentySprzedazyLinijki");
            modelBuilder.Entity<PosOrderItem>().Property(d => d.Id).HasColumnName("DSL_ID");
            modelBuilder.Entity<PosOrderItem>().Property(d => d.PosOrderId).HasColumnName("DSL_DSRID");
            modelBuilder.Entity<PosOrderItem>().Property(d => d.MenuItemId).HasColumnName("DSL_ARTID");
            modelBuilder.Entity<PosOrderItem>().Property(d => d.CancellationDate).HasColumnName("DSL_DataStorna");

            modelBuilder.Entity<PosOrderItem>().HasOne(i => i.PosOrder).WithMany(b => b.PosOrderItems).HasForeignKey(p => p.PosOrderId);
            modelBuilder.Entity<PosOrderItem>().HasOne(p => p.MenuItem).WithMany();

            modelBuilder.Entity<MenuItem>().ToTable("ART_Artykuly");
            modelBuilder.Entity<MenuItem>().Property(d => d.Id).HasColumnName("ART_ID");
            modelBuilder.Entity<MenuItem>().Property(d => d.Name).HasColumnName("ART_Nazwa");

            modelBuilder.Entity<MenuItemCategory>().ToTable("AXK_ArtXKat");
            modelBuilder.Entity<MenuItemCategory>().Property(d => d.Id).HasColumnName("AXK_ID");
            modelBuilder.Entity<MenuItemCategory>().Property(d => d.CategoryId).HasColumnName("AXK_KATID");
            modelBuilder.Entity<MenuItemCategory>().Property(d => d.MenuItemId).HasColumnName("AXK_ARTID");          

            base.OnModelCreating(modelBuilder);
        }
    }
}
