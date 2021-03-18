
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ParchaseInvoices.Contracs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/parchase-invoces")]
    [ApiController]
    public class ParchaseInvoiceController : ControllerBase
    {
        private readonly ParchaseInvoiceService _service;

        public ParchaseInvoiceController(ParchaseInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Register(RegisteParchaseInvoiceDto dto)
        {
            return await _service.Register(dto);
        }

    }
}
