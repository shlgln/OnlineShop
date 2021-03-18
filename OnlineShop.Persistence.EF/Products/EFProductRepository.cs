using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Products.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<Product> _set;
        public EFProductRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.Products;
        }

        public void Add(Product product)
        {
            _set.Add(product);
        }

        public async Task<Product> FindProductById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetAllProductDto>> GetAllProducts()
        {
            var products = _set.Select(_ => new GetAllProductDto
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
            return await _set.AnyAsync(_ => _.Code == code);
        }

        public async Task<bool> IsDuplicateProductTitleInCategory(string title, int productCategoryId)
        {
            return await _set.AnyAsync(_ => _.Title == title && _.ProductCategoryId == productCategoryId);
        }

        async Task<FindProductDto> ProductRepository.FindById(int id)
        {
            var product = _set.Where(_ => _.Id == id).Select(_ => new FindProductDto
            {
                Id = _.Id,
                Title = _.Title,
                Code = _.Code,
                MinimumStack = _.MinimumStack,
                Category= _.ProductCategory.Title

            }).FirstOrDefaultAsync();

            return await product;
        }
    }
}
