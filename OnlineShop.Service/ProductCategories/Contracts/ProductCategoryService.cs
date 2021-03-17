using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryService
    {
        Task<int> Register(RegisterProductCategoryDto dto);
        Task<IList<GetAllProductCategoryDto>> GetAll();
    }
}
