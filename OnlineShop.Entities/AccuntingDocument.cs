using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class AccuntingDocument
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string SaleInvoiceNumber { get; set; }
        public int SaleInvoiceId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public SaleInvoice SaleInvoice { get; set; }

    }
}
