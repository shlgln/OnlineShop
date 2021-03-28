using OnlineShop.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.AccountingDocuments.Contracts
{
    public interface AccountingDocumentRepository : Repository
    {
        Task<bool> IsDuplicatedAccountingNumber(string number);
    }
}
