using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IList<GetAllProductCategoryDto>> GetAllProductCategories()
        {
            var categories = _dataContext.ProductCategories.Select(_ => new GetAllProductCategoryDto
            {
                Id = _.Id,
                Title = _.Title

            });

            return await categories.ToListAsync();
        }
    }
}
