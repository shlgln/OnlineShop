using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public class GetAllProductCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<string> products  { get; set; }
    }
}
