using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Entities;
using OnlineShop.Services.StoreRooms.Contracs;
using OnlineShop.Services.StoreRooms.Contracs.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.RestApi.Controllers
{
    [Route("api/storeRooms")]
    [ApiController]
    public class StoreRoomController : ControllerBase
    {
        private readonly StoreRoomService _service;

        public StoreRoomController(StoreRoomService servic)
        {
            _service = servic;
        }

        [HttpGet]
        public async Task<IList<StoreRoomInventoryListDto>> GetAll()
        {
            return await _service.GetAllStoreRoomInventoryList();
        }

        [HttpGet("{sort}")]
        public async Task<IList<StoreRoomInventoryListDto>> GetAllByQueryFilter([FromQuery]StoreRoomQueryFilter filter, string sort)
        {
            return  await _service.GetStoreRoomInventoryList(filter, sort);
        }
    }
}
