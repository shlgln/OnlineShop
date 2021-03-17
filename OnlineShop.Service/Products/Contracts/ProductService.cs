using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductService
    {
        Task<int> Register(RegisterProductDto dto);
        Task<IList<GetAllProductDto>> GetAll();
    }
}
