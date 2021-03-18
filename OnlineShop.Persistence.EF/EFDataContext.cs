using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF
{
    public class EFDataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder _)
        {
            _.UseSqlServer("Server=.;Database=OnlineShop;Trusted_Connection=True;");
            base.OnConfiguring(_);
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ParchaseInvoice> ParchaseInvoices { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<SaleInvoiceItem> SaleInvoiceItems { get; set; }
        public DbSet<StoreRoom> StoreRooms { get; set; }
        public DbSet<AccuntingDocument> AccuntingDocuments { get; set; }
    }
}
