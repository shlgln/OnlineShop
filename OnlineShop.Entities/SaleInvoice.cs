using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class SaleInvoice
    {
        public SaleInvoice()
        {
            saleInvoiceItems = new HashSet<SaleInvoiceItem>();
            AccuntingDocuments = new HashSet<AccuntingDocument>();
        }
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public int CustomerName { get; set; }
        public DateTime Date { get; set; }
        public HashSet<SaleInvoiceItem> saleInvoiceItems { get; set; }
        public HashSet<AccuntingDocument> AccuntingDocuments { get; set; }
    }
}
