using OnlineShop.Services.Queris.StoreRoomQueryis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public interface StoreRoomService
    {
        IList<StoreRoomInventoryListDto> GetStoreRoomsByQuery(StoreRoomQueryFilter filter, string sort);
        Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventoryList();
    }
}
