using OnlineShop.Infrastructure.Application;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext _dataContext;
        public EFUnitOfWork(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void CommitPartial()
        {
            throw new NotImplementedException();
        }

        public async  Task Complete()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
