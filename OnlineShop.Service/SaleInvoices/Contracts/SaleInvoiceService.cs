using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.SaleInvoices.Contracts
{
    public interface SaleInvoiceService
    {
        Task<int> Register(RegisterSaleInvoiceDto dto);
    }
}
