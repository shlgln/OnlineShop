using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.StoreRooms.Contracs;
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
            return await _service.GetStoreRoomEnventoryList();
        }
    }
}
