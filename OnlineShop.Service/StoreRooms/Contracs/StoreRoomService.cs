using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public interface StoreRoomService
    {
        Task<IList<StoreRoomInventoryListDto>> GetStoreRoomEnventoryList();
    }
}
