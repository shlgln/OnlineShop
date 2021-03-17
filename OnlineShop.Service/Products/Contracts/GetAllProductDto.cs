using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Products.Contracts
{
    public class GetAllProductDto
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumStack { get; set; }
        public string Category { get; set; }
    }
}
