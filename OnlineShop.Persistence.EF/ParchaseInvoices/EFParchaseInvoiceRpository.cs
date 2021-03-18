using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.ParchaseInvoices.Contracs;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.ParchaseInvoices
{
    public class EFParchaseInvoiceRpository: ParchaseInvoiceRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<ParchaseInvoice> _set;
        public EFParchaseInvoiceRpository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.ParchaseInvoices;
        }

        public void Add(ParchaseInvoice parchaseInvoice)
        {
            _set.Add(parchaseInvoice);
        }

        public async Task<bool> IsDuplicatedInvoiceNumber(string number)
        {
            return await _set.AnyAsync(_ => _.Number == number);
        }
    }
}
