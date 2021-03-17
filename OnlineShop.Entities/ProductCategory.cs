using OnlineShop.Infrastructure.Domian;
using System.Collections.Generic;

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
