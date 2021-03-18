using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductService: Service
    {
        Task<int> Register(RegisterProductDto dto);
        Task<IList<GetAllProductDto>> GetAll();
        Task<FindProductDto?> FindProductById(int id);
    }
}
