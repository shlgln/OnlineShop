using OnlineShop.Infrastructure.Application;
using System.Threading.Tasks;

namespace OnlineShop.Services.ParchaseInvoices.Contracs
{
    public interface ParchaseInvoiceService: Service
    {
        Task<int> Register(RegisteParchaseInvoiceDto dto);
    }
}
