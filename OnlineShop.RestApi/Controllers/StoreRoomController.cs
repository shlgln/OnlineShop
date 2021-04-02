using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.StoreRooms.Contracs;
using OnlineShop.Services.StoreRooms.Queris;
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

        [HttpGet("{ordering}/{sortOrder}")]
        public IList<StoreRoomInventoryListDto> GetAllByQueryFilter([FromQuery]StoreRoomQueryFilter filter,
            string ordering, bool sortOrder)
        {
            var result = _service.GetStoreRoomsByQuery(filter, ordering, sortOrder);
            return  result;
        }
    }
}
