using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public HashSet<Product> Products { get; set; }
    }
}
