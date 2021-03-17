using OnlineShop.Infrastructure.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class Product: Entity<int>
    {
        public Product()
        {
            ParchaseInvoices = new HashSet<ParchaseInvoice>();
            SaleInvoiceItems = new HashSet<SaleInvoiceItem>();
            StoreRooms = new HashSet<StoreRoom>();
        }
        public int  ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string  Code { get; set; }
        public int MinimumStack { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public HashSet<ParchaseInvoice> ParchaseInvoices { get; set; }
        public HashSet<StoreRoom> StoreRooms { get; set; }
        public HashSet<SaleInvoiceItem> SaleInvoiceItems { get; set; }
    }
}
