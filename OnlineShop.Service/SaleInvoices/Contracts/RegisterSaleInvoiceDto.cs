using OnlineShop.Entities;
using OnlineShop.Services.AccountingDocuments.Contracts;
using OnlineShop.Services.SaleInvoiceItems.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.SaleInvoices.Contracts
{
    public class RegisterSaleInvoiceDto
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public IList<SalesInvoiceItemDto> SaleInvoiceItems { get; set; }
        public RegisterAccountingDto accountingDocumentDto { get; set; }
    }
}
