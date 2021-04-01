using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Queris.StoreRoomQueryis;
using OnlineShop.Services.StoreRooms.Contracs;
using System.Collections.Generic;
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

        [HttpGet("{ordering}")]
        public IList<StoreRoomInventoryListDto> GetAllByQueryFilter([FromQuery]StoreRoomQueryFilter filter,
            string ordering)
        {
            var result = _service.GetStoreRoomsByQuery(filter, ordering);
            return  result;
        }
    }
}
