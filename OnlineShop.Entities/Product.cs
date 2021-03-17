using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class Product
    {
        public Product()
        {
            ParchaseInvoices = new HashSet<ParchaseInvoice>();
            InvoiceItems = new HashSet<SaleInvoiceItem>();
            StoreRooms = new HashSet<StoreRoom>();
        }
        public int Id { get; set; }
        public int  ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string  Code { get; set; }
        public int MinimumStack { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public HashSet<ParchaseInvoice> ParchaseInvoices { get; set; }
        public HashSet<StoreRoom> StoreRooms { get; set; }
        public HashSet<SaleInvoiceItem> InvoiceItems { get; set; }
    }
}
