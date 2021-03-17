
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public class RegisterProductCategoryDto
    {
        [Required]
        public string  Title { get; set; }
    }
}
