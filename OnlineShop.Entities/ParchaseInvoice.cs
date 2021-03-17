using OnlineShop.Infrastructure.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class ParchaseInvoice: Entity<int>
    {
        public string Number { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public DateTime DateRegistration { get; set; }
        public Product Product { get; set; }
    }
}
