using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.SaleInvoiceItems.Contracts;
using OnlineShop.Services.SaleInvoices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.SaleInvoices
{
    public class EFSaleInvoiceRepository : SaleInvoiceRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<SaleInvoice> _set;
        public EFSaleInvoiceRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.SaleInvoices;
        }
        public void Add(SaleInvoice saleInvoice)
        {
            _set.Add(saleInvoice);
        }

        public async Task<bool> IsDuplicatedInvoiceNumber(string number)
        {
            return await _set.AnyAsync(_ => _.Number == number);
        }
    }
}
