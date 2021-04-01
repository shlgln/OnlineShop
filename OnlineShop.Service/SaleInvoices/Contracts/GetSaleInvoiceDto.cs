using OnlineShop.Entities;
using OnlineShop.Services.SaleInvoiceItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.SaleInvoices.Contracts
{
    public class GetSaleInvoiceDto
    {
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateRegistration { get; set; }
        public List<GetSaleInvoiceItemDto> saleInvoiceItems { get; set; }
    }
}
