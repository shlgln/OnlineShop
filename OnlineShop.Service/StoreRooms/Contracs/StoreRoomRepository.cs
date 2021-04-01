using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Queris.StoreRoomQueryis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public interface StoreRoomRepository:Repository
    {
        void Add(StoreRoom storeRoom);
        Task<StoreRoom> FindByProductId(int productId);
        IQueryable<StoreRoomInventoryListDto> GetStoreRoomsByQuery();
        IList<StoreRoomInventoryListDto> SetStoreRoomFilter
            (IEnumerable<StoreRoomInventoryListDto> storeRoom,
            StoreRoomQueryFilter filter);
        IQueryable<StoreRoomInventoryListDto> SetStoreRoomSort(IQueryable<StoreRoomInventoryListDto> entities,
            string ordering);
        Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventory();
    }
}
