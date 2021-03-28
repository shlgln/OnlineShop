using OnlineShop.Entities;
using OnlineShop.Services.AccountingDocuments.Contracts;
using OnlineShop.Services.SaleInvoiceItems.Contracts;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.SaleInvoices.Contracts
{
    public class RegisterSaleInvoiceDto
    {
        //public RegisterSaleInvoiceDto()
        //{
        //    saleInvoiceItems = new HashSet<SaleInvoiceItem>();
        //    AccuntingDocuments = new HashSet<AccuntingDocument>();
        //}
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public IList<SalesInvoiceItemDto> SaleInvoiceItems { get; set; }

        //public HashSet<SaleInvoiceItem> saleInvoiceItems { get; set; }
        public RegisterAccountingDto dto { get; set; }
    }
}
