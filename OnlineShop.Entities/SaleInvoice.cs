using OnlineShop.Infrastructure.Domian;
using System;
using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class SaleInvoice: Entity<int>
    {
        public SaleInvoice()
        {
            saleInvoiceItems = new List<SaleInvoiceItem>();
            AccountingDocuments = new HashSet<AccountingDocument>();
        }
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateRegistration { get; set; }
        public List<SaleInvoiceItem> saleInvoiceItems { get; set; }
        public HashSet<AccountingDocument> AccountingDocuments { get; set; }
    }
}
