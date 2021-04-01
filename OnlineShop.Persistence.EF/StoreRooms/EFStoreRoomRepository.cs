using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Queris.StoreRoomQueryis;
using OnlineShop.Services.StoreRooms.Contracs;
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
                ProductCode = _.Product.Code,
                ProductTitle = _.Product.Title,
                CategoryTitle = _.Product.ProductCategory.Title,
                Stock = _.Stock,
                MinimumStock = _.Product.MinimumStack,
            });
            
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
            string ordering)
        {
            var type = typeof(StoreRoomInventoryListDto);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy",
                new Type[] { type, property.PropertyType },
                entities.Expression, Expression.Quote(orderByExp));
            return entities.Provider.CreateQuery<StoreRoomInventoryListDto>(resultExp);
        }
    }
}
