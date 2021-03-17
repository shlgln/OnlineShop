using OnlineShop.Infrastructure.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class SaleInvoiceItem: Entity<int>
    {
        public int SaleInvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal Price { get; set; }
        public Product  Product { get; set; }

        public SaleInvoice SaleInvoice { get; set; }
    }
}
