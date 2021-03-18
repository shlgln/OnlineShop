using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Entities;
using OnlineShop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Register([FromBody] RegisterProductDto dto)
        {
            return await _service.Register(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<FindProductDto?> GetAll([FromRoute] int id)
        {
            return await _service.FindProductById(id);
        }
    }
}
