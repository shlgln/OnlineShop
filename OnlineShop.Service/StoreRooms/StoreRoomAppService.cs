using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.StoreRooms.Contracs;
using OnlineShop.Services.StoreRooms.Contracs.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms
{
    public class StoreRoomAppService : StoreRoomService
    {
        private readonly StoreRoomRepository _repository;

        private readonly UnitOfWork _unitOfWork;

        public StoreRoomAppService(StoreRoomRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventoryList()
        {
            var storRoomItems = await _repository.GetAllStoreRoomInventory();
            return  storRoomItems;
        }

        public async Task<IList<StoreRoomInventoryListDto>> GetStoreRoomInventoryList(StoreRoomQueryFilter filter, string sort)
        {
            var storRoomItems = await _repository.GetAllStoreRoomInventory();

            var storeroomsort= await GetStoreRoomSort(storRoomItems, sort);

            var storeRoomFilter = await GetStoreRoomFilter(storeroomsort, filter);

            var paged = PagedList<StoreRoomInventoryListDto>.Create(storeRoomFilter, filter.PageNumber, filter.PageSize);
            return  paged;
        }

        private async Task<IList<StoreRoomInventoryListDto>> GetStoreRoomFilter(IList<StoreRoomInventoryListDto> storeRoom, StoreRoomQueryFilter filter)
        {
            
            if (filter.ProductCode != null)
                storeRoom = storeRoom
                .Where(_ => _.ProductCode == filter.ProductCode).ToList();

            if (filter.ProductTitle != null)
                storeRoom = storeRoom.Where(_ => _.ProductTitle.ToLower()
                .Contains(filter.ProductTitle.ToLower())).ToList();

            if (filter.CategoryTitle != null)
                storeRoom = storeRoom.Where(_ => _.CategoryTitle.ToLower()
                .Contains(filter.CategoryTitle.ToLower())).ToList();

            if (filter.Stock != null)
                storeRoom = storeRoom
                .Where(_ => _.Stock == filter.Stock).ToList();

            if (filter.MinimumStock != null)
                storeRoom = storeRoom
                .Where(_ => _.MinimumStock == filter.MinimumStock).ToList();

            if (filter.Status != null)
                storeRoom = storeRoom
                .Where(_ => _.Status == filter.Status).ToList();
            
            return  storeRoom;
        }

        private async Task<IList<StoreRoomInventoryListDto>> GetStoreRoomSort(IList<StoreRoomInventoryListDto> storeRoom, string sort)
        {

            if (sort == "ProductCode")
                storeRoom = storeRoom.OrderByDescending(_ => _.ProductCode).ToList();

            if (sort ==  "ProductTitle")
                storeRoom = storeRoom.OrderByDescending(_ => _.ProductTitle).ToList();

            if (sort == "CategoryTitle")
                storeRoom = storeRoom.OrderByDescending(_ => _.CategoryTitle).ToList();

            if (sort == "Stock")
                storeRoom = storeRoom.OrderByDescending(_ => _.Stock).ToList();

            if (sort == "MinimumStock")
                storeRoom = storeRoom.OrderByDescending(_ => _.MinimumStock).ToList();

            if (sort == "Status")
                storeRoom = storeRoom.OrderByDescending(_ => _.Status).ToList();

            return  storeRoom;
        }
    }
}
