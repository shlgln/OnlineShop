using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.Products.Contracts
{
    public class RegisterProductDto
    {
        [Required]
        public int ProductCategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int MinimumStack { get; set; }
    }
}
