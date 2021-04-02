using OnlineShop.Services.StoreRooms.Queris;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public interface StoreRoomService
    {
        IList<StoreRoomInventoryListDto> GetStoreRoomsByQuery(StoreRoomQueryFilter filter, string sort, bool sortingOrder);
        Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventoryList();
    }
}
