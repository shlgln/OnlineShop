using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.StoreRooms.Contracs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.StoreRooms
{
    public class EFStoreRoomRepository : StoreRoomRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<StoreRoom> _set;
        public EFStoreRoomRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
           _set = _dataContext.StoreRooms;
        }
        public void Add(StoreRoom storeRoom)
        {
            _set.Add(storeRoom);

        }

        public async Task<StoreRoom> FindByProductId(int productId)
        {
            return await _set.SingleOrDefaultAsync(_ => _.ProductId == productId);
        }

        public async Task<IList<StoreRoomInventoryListDto>> GetAllStoreRoomInventory()
        {
            
            var query = from p in _dataContext.Products
                        join s in _set on p.Id equals s.ProductId
                        select new StoreRoomInventoryListDto
                        {
                            ProductCode = p.Code,
                            ProductTitle = p.Title,
                            CategoryTitle = p.ProductCategory.Title,
                            Stock = s.Stock,
                            MinimumStock = p.MinimumStack,                            
                        };

            return await query.ToListAsync();
        }
    }
}
