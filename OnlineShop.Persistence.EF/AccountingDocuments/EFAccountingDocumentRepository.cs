using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.AccountingDocuments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.AccountingDocuments
{
    public class EFAccountingDocumentRepository : AccountingDocumentRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<AccountingDocument> _set;
        public EFAccountingDocumentRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.AccuntingDocuments;
        }

        public async Task<bool> IsDuplicatedAccountingNumber(string number)
        {
            return await _set.AnyAsync(_ => _.Number == number);
        }
    }
}
