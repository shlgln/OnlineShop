using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class SaleInvoiceItem
    {
        public int Id { get; set; }
        public int SaleInvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal Price { get; set; }
        public Product  Product { get; set; }

        public SaleInvoice SaleInvoice { get; set; }
    }
}
