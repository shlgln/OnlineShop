using OnlineShop.Infrastructure.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class ProductCategory: Entity<int>
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
        public string Title { get; set; }
        public HashSet<Product> Products { get; set; }
    }
}
