using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _dataContext;
        public EFProductRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Product product)
        {
            _dataContext.Add(product);
        }

        public async Task<IList<GetAllProductDto>> GetAllProducts()
        {
            var products = _dataContext.Products.Select(_ => new GetAllProductDto
            {
                Title = _.Title,
                Code = _.Code,
                MinimumStack = _.MinimumStack,
                Category = _.ProductCategory.Title
            }).ToListAsync();

            return await products;
        }

        public async Task<bool> IsDuplicateProductCode(string code)
        {
            return await _dataContext.Products.AnyAsync(_ => _.Code == code);
        }

        public async Task<bool> IsDuplicateProductTitleInCategory(string title, int productCategoryId)
        {
            return await _dataContext.Products.AnyAsync(_ => _.Title == title && _.ProductCategoryId == productCategoryId);
        }

        async Task<FindProductDto> ProductRepository.FindById(int id)
        {
            var product = _dataContext.Products.Select(_ => new FindProductDto
            {
                Id = _.Id,
                Title = _.Title,
                Code = _.Code,
                MinimumStack = _.MinimumStack,
                Category= _.ProductCategory.Title
            }).Where(_ => _.Id == id).FirstOrDefaultAsync();

            return await product;
        }
    }
}
