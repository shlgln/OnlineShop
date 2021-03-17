using OnlineShop.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        void Add(ProductCategory productCategory);
        Task<IList<GetAllProductCategoryDto>> GetAllProductCategories();
    }
}
