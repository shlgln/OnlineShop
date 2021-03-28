using OnlineShop.Entities;
using OnlineShop.Services.StoreRooms.Contracs.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public interface StoreRoomService
    {
        Task<IList<StoreRoomInventoryListDto>> GetStoreRoomInventoryList(StoreRoomQueryFilter filter, string sort);
        Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventoryList();
    }
}
