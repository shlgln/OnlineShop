using OnlineShop.Services.Queries;
using OnlineShop.Services.Queris.StoreRoomQueryis;
using OnlineShop.Services.StoreRooms.Contracs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms
{
    public class StoreRoomAppService : StoreRoomService
    {
        private readonly StoreRoomRepository _repository;
        public StoreRoomAppService(StoreRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventoryList()
        {
            var storRoomItems = await _repository.GetAllStoreRoomInventory();
            return  storRoomItems;
        }

        public IList<StoreRoomInventoryListDto> GetStoreRoomsByQuery(StoreRoomQueryFilter filter, string ordering)
        {
            var storRoomItems =  _repository.GetStoreRoomsByQuery();
            storRoomItems = _repository.SetStoreRoomSort(storRoomItems, ordering);
            var list = _repository.SetStoreRoomFilter(storRoomItems, filter);
           

            var paged = PagedList<StoreRoomInventoryListDto>.Create(list, filter.PageNumber, filter.PageSize);
            return  paged;
        }

    }
}
