using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SaleInvoiceItems.Contracts
{
    public class SalesInvoiceItemDto
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int Price { get; set; }
    }
}
