using OnlineShop.Infrastructure.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class StoreRoom: Entity<int>
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public Product Product { get; set; }
    }
}
