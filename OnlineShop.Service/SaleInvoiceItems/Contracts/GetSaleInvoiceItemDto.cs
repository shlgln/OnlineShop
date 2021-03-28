using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SaleInvoiceItems.Contracts
{
    public class GetSaleInvoiceItemDto
    {
        public string saleNumber { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductCount { get; set; }
        public decimal Price { get; set; }
    }
}
