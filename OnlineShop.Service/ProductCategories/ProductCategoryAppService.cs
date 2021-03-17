using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;

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
        public int Register(RegisterProductCategoryDto dto)
        {
            var productCategory = new ProductCategory
            {
                Title = dto.Title
            };
            _repository.Add(productCategory);
            _unitOfWork.Complete();
            return productCategory.Id;


        }
    }
}
