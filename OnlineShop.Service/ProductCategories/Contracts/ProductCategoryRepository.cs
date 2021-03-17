using OnlineShop.Entities;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        void Add(ProductCategory productCategory);
    }
}
