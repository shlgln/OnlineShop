using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Application
{
    public interface UnitOfWork
    {
        void Begin();
        void CommitPartial();
        void Commit();
        void Rollback();
        void Complete();
    }
}
