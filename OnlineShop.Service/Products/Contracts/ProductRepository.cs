using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductRepository
    {
        Task<bool> IsDuplicateProductCode(string code);
        void Add(Product product);
        Task<bool> IsDuplicateProductTitleInCategory(string title, int productCategoryId);
        Task<IList<GetAllProductDto>> GetAllProducts();
        Task<FindProductDto> FindById(int id);
    }
}
