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
        private readonly DbSet<ProductCategory> _set;
        public EFProductCategoryRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.ProductCategories;
        }
        public void Add(ProductCategory productCategory)
        {
            _set.Add(productCategory);
        }

        public async Task<IList<GetAllProductCategoryDto>> GetAllProductCategories()
        {
            //var categories = _set.Select(_ => new GetAllProductCategoryDto
            //{
            //    Id = _.Id,
            //    Title = _.Title

            //});
            //return await categories.ToListAsync();

            var query = from a in _set
                        select new GetAllProductCategoryDto
                        {
                            Id = a.Id,
                            Title = a.Title,
                            products = a.Products.Select(m => m.Title).ToList(),
                        };



            return await query.ToListAsync();
        }

        public Task<bool> IsDuplicatedCategoryTitle(string title)
        {
            return _set.AnyAsync(_ => _.Title == title);
        }
    }
}
