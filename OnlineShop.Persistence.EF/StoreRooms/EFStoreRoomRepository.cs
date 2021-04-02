using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.StoreRooms.Contracs;
using OnlineShop.Services.StoreRooms.Queris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return await _set.Select(_ => new StoreRoomInventoryListDto
            {
                ProductCode = _.Product.Code,
                ProductTitle = _.Product.Title,
                CategoryTitle = _.Product.ProductCategory.Title,
                Stock = _.Stock,
                MinimumStock = _.Product.MinimumStack,
            }).ToListAsync();
        }

        public IQueryable<StoreRoomInventoryListDto> GetStoreRoomsByQuery()
        {
            var query = _set.Select(_ => new StoreRoomInventoryListDto
            {
                Id = _.Id,
                ProductCode = _.Product.Code,
                ProductTitle = _.Product.Title,
                CategoryTitle = _.Product.ProductCategory.Title,
                Stock = _.Stock,
                MinimumStock = _.Product.MinimumStack,
            });;
            
            return query;
        }

        public IList<StoreRoomInventoryListDto> SetStoreRoomFilter(IEnumerable<StoreRoomInventoryListDto> storeRoom,
            StoreRoomQueryFilter filter)
        {
            if (filter.ProductCode != null)
                storeRoom = storeRoom
                .Where(_ => _.ProductCode == filter.ProductCode);

            if (filter.ProductTitle != null)
                storeRoom = storeRoom.Where(_ => _.ProductTitle.ToLower()
                .Contains(filter.ProductTitle.ToLower()));

            if (filter.CategoryTitle != null)
                storeRoom = storeRoom.Where(_ => _.CategoryTitle.ToLower()
                .Contains(filter.CategoryTitle.ToLower()));

            if (filter.Stock != null)
                storeRoom = storeRoom
                .Where(_ => _.Stock == filter.Stock);

            if (filter.MinimumStock != null)
                storeRoom = storeRoom
                .Where(_ => _.MinimumStock == filter.MinimumStock);

            if (filter.Status != null)
                storeRoom = storeRoom
                .Where(_ => _.Status == filter.Status);

            return storeRoom.ToList();
        }
        public IQueryable<StoreRoomInventoryListDto> SetStoreRoomSort(IQueryable<StoreRoomInventoryListDto> entities,
            string ordering, bool sortingOrder)
        {
            if (sortingOrder)
                return SetStoreRoomOrderByASC(entities, ordering);

            return SetStoreRoomOrderByDESC(entities, ordering);
        }

        private IQueryable<StoreRoomInventoryListDto> SetStoreRoomOrderByASC(IQueryable<StoreRoomInventoryListDto> entities,
           string ordering)
        {
            if (ordering == "")
                entities = entities.OrderBy(_ => _.Id);

            if (ordering == "productTitle")
                entities = entities.OrderBy(_ => _.ProductTitle);

            if (ordering == "stock")
                entities = entities.OrderBy(_ => _.Stock);


            if (ordering == "productCode")
                entities = entities.OrderBy(_ => _.ProductCode);

            if (ordering == "minimumStock")
                entities = entities.OrderBy(_ => _.MinimumStock);

            if (ordering == "minimumStock")
                entities = entities.OrderBy(_ => _.MinimumStock);

            if (ordering == "categoryTitle")
                entities = entities.OrderBy(_ => _.CategoryTitle);

            if (ordering == "Status")
                entities = entities.OrderBy(_ => _.Status);

            return entities;
        }

        private IQueryable<StoreRoomInventoryListDto> SetStoreRoomOrderByDESC(IQueryable<StoreRoomInventoryListDto> entities,
            string ordering)
        {
            if (ordering == "")
                entities = entities.OrderByDescending(_ => _.Id);

            if (ordering == "productTitle")
                entities = entities.OrderByDescending(_ => _.ProductTitle);

            if (ordering == "stock")
                entities = entities.OrderByDescending(_ => _.Stock);


            if (ordering == "productCode")
                entities = entities.OrderByDescending(_ => _.ProductCode);

            if (ordering == "minimumStock")
                entities = entities.OrderByDescending(_ => _.MinimumStock);

            if (ordering == "minimumStock")
                entities = entities.OrderByDescending(_ => _.MinimumStock);

            if (ordering == "categoryTitle")
                entities = entities.OrderByDescending(_ => _.CategoryTitle);

            if (ordering == "Status")
                entities = entities.OrderByDescending(_ => _.Status);

            return entities;
        }
    }
}
