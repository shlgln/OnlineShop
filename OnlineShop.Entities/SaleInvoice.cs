using OnlineShop.Infrastructure.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class SaleInvoice: Entity<int>
    {
        public SaleInvoice()
        {
            saleInvoiceItems = new HashSet<SaleInvoiceItem>();
            AccuntingDocuments = new HashSet<AccuntingDocument>();
        }
        public string Number { get; set; }
        public int CustomerName { get; set; }
        public DateTime DateRegistration { get; set; }
        public HashSet<SaleInvoiceItem> saleInvoiceItems { get; set; }
        public HashSet<AccuntingDocument> AccuntingDocuments { get; set; }
    }
}
