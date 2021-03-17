using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ProductCategories.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/product-categories")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryService _service;
        public ProductCategoryController(ProductCategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public int Register(RegisterProductCategoryDto dto)
        {
            return _service.Register(dto);
        }
    }
}
