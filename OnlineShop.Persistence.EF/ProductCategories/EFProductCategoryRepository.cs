using OnlineShop.Entities;
using OnlineShop.Services.ProductCategories.Contracts;
using System;

namespace OnlineShop.Persistence.EF.ProductCategories
{
    public class EFProductCategoryRepository : ProductCategoryRepository
    {
        private readonly EFDataContext _dataContext;
        public EFProductCategoryRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(ProductCategory productCategory)
        {
            _dataContext.Add(productCategory);
        }
    }
}
