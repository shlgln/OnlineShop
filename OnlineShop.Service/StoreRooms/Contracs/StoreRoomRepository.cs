using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public interface StoreRoomRepository:Repository
    {
        void Add(StoreRoom storeRoom);
        Task<StoreRoom> FindByProductId(int productId);
        Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventory();
    }
}
