using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
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

        public async Task<int> Register(RegisterProductDto dto)
        {
            if (await _repository.IsDuplicateProductCode(dto.Code))
                throw new DuplicateProductCodeException();

            if (await _repository.IsDuplicateProductTitleInCategory(dto.Title, dto.ProductCategoryId))
                throw new DuplicateProductTitleInCategoryException();

            var product = new Product
            {
                ProductCategoryId = dto.ProductCategoryId,
                Title = dto.Title,
                Code = dto.Code,
                MinimumStack = dto.MinimumStack
            };
            _repository.Add(product);
            await _unitOfWork.Complete();
            return product.Id;
        }
    }
}
