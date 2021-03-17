using OnlineShop.Infrastructure.Domian;
using System;

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
