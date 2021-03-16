using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class AccuntingDocument
    {
        public int Id { get; set; }
        public string DocumnetNumber { get; set; }
        public string SaleInvoiceNumber { get; set; }
        public int SaleInvoiceId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
