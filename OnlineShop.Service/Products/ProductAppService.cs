using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Products
{
    public class ProductAppService : ProductService
    {
        private readonly ProductRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public ProductAppService(ProductRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<FindProductDto> FindProductById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _repository.GetAllProducts();
        }

        public async Task<int> Register(RegisterProductDto dto)
        {

            await CheckDuplicateProductCode(dto.Code);

            await CheckDuplicateProductTitleInCategory(dto.Title, dto.ProductCategoryId);

            var product = new Product
            {
                ProductCategoryId = dto.ProductCategoryId,
                Title = dto.Title,
                Code = dto.Code,
                MinimumStack = dto.MinimumStack
            };
            _repository.Add(product);

            var storeRoom = new HashSet<StoreRoom>
            {
                new StoreRoom
                {
                    ProductId = product.Id,
                    Stock = 0
                }
            };
            product.StoreRooms = storeRoom;
           
            await _unitOfWork.Complete();
            return product.Id;
        }

        private async Task CheckDuplicateProductCode(string code)
        {
            if (await _repository.IsDuplicateProductCode(code))
                throw new DuplicateProductCodeException();
        }
        private async Task CheckDuplicateProductTitleInCategory(string title, int categoryId)
        {
            if (await _repository.IsDuplicateProductTitleInCategory(title, categoryId))
                throw new DuplicateProductTitleInCategoryException();
        }
    }
}
