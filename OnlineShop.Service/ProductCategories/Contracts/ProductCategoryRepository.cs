using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository: Repository
    {
        void Add(ProductCategory productCategory);
        Task<IList<GetAllProductCategoryDto>> GetAllProductCategories();
        Task<bool> IsDuplicatedCategoryTitle(string title);
    }
}
