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
        public int ProductId { get; set; }
        public int  ProductCategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string  ProductCode { get; set; }
        public int productMinimumStack { get; set; }
        public HashSet<ParchaseInvoice> ParchaseInvoices { get; set; }
        public HashSet<StoreRoom> StoreRooms { get; set; }
    }
}
