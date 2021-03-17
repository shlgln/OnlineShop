using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Products.Contracts
{
    public class FindProductById
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public int Minimumstack { get; set; }
    }
}
