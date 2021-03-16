using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class ParchaseInvoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
    }
}
