using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShop.Services.Products.Contracts
{
    public class FindProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumStack { get; set; }
        public string Category { get; set; }
    }
}
