using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Entities;
using OnlineShop.Services.SaleInvoices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/saleInvoices")]
    [ApiController]
    public class SaleInvoiceController : ControllerBase
    {
        private readonly SaleInvoiceService _service;
        public SaleInvoiceController(SaleInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Register(RegisterSaleInvoiceDto dto)
        {
            return await _service.Register(dto);
        }

        [HttpGet]
        public async Task<IList<GetSaleInvoiceDto>> Get()
        {
            return await _service.GetAll();
        }

    }
}
