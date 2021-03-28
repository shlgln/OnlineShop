using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SaleInvoices.Contracts
{
    public interface SaleInvoiceRepository : Repository
    {
        void Add(SaleInvoice saleInvoice);
        Task<bool> IsDuplicatedInvoiceNumber(string number);
    }
}
