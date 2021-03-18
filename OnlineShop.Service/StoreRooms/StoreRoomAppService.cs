using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.StoreRooms.Contracs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.StoreRooms
{
    public class StoreRoomAppService: StoreRoomService
    {
        private readonly StoreRoomRepository _repository;

        private readonly UnitOfWork _unitOfWork;

        public StoreRoomAppService(StoreRoomRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<StoreRoomInventoryListDto>> GetStoreRoomEnventoryList()
        {
            return await _repository.GetAllStoreRoomEnventory();
        }
    }
}
