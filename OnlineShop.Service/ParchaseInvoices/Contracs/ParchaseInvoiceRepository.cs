using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using System.Threading.Tasks;

namespace OnlineShop.Services.ParchaseInvoices.Contracs
{
    public interface ParchaseInvoiceRepository : Repository
    {
        Task<bool> IsDuplicatedInvoiceNumber(string number);
        void Add(ParchaseInvoice storeProduct);
    }
}
