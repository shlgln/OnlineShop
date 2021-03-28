using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.ProductCategories.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductCategories
{
    public class ProductCategoryAppService : ProductCategoryService
    {
        private readonly ProductCategoryRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public ProductCategoryAppService(ProductCategoryRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllProductCategoryDto>> GetAll()
        {
            return await _repository.GetAllProductCategories();
        }

        public async Task<int> Register(RegisterProductCategoryDto dto)
        {
            if (await _repository.IsDuplicatedCategoryTitle(dto.Title))
                throw new DuplicatedCategoryTitleException();

            var productCategory = new ProductCategory
            {
                Title = dto.Title
            };
             _repository.Add(productCategory);
             await _unitOfWork.Complete();
            return  productCategory.Id;
        }
    }
}
