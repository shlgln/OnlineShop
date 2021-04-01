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

        public async Task<IList<GetSaleInvoiceDto>> GetAll()
        {
            var query = from invoice in _set
                        select new GetSaleInvoiceDto
                        {
                            Number = invoice.Number,
                            CustomerName = invoice.CustomerName,
                            saleInvoiceItems = invoice.saleInvoiceItems.Select(_ => new GetSaleInvoiceItemDto
                            {
                                ProductId = _.ProductId,
                                ProductTitle = _.Product.Title,
                                ProductCount = _.ProductCount,
                                Price = _.Price
                            }).ToList()
                        };
            return await query.ToListAsync();
        }

        public async Task<bool> IsDuplicatedInvoiceNumber(string number)
        {
            return await _set.AnyAsync(_ => _.Number == number);
        }
    }
}
