using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ProductCategories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<int> Register([FromBody] RegisterProductCategoryDto dto)
        {
            return await _service.Register(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllProductCategoryDto>> GetAll()
        {
            return await _service.GetAll();
        }


    }
}
