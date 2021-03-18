using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ParchaseInvoices.Contracs;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.StoreRooms.Contracs;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Services.ParchaseInvoices
{
    public class ParchaseInvoiceAppService: ParchaseInvoiceService
    {
        private readonly ParchaseInvoiceRepository _repository;
        private readonly ProductRepository _productRepository;
        private readonly StoreRoomRepository _storeRoomRepository;
        private readonly UnitOfWork _unitOfWork;

        public ParchaseInvoiceAppService(ParchaseInvoiceRepository repository, ProductRepository productRepository, StoreRoomRepository storeRoomRepository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _productRepository = productRepository;
            _storeRoomRepository = storeRoomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Register(RegisteParchaseInvoiceDto dto)
        {
            await CheckIsExistProduct(dto.ProductId);

            var productInStorRoom = await  _storeRoomRepository.FindByProductId(dto.ProductId);


            var parchaseInvoice = new ParchaseInvoice
            {
                Number = dto.Number,
                ProductCount = dto.ProductCount,
                DateRegistration = DateTime.Now,
                ProductId = dto.ProductId
            };
          
            _repository.Add(parchaseInvoice);


            productInStorRoom.Stock += parchaseInvoice.ProductCount;

            await _unitOfWork.Complete();

            return parchaseInvoice.Id;
        }

        private async Task CheckIsExistProduct(int id)
        {
            var product = await _productRepository.FindProductById(id);
            if (product == null)
                throw new NotFoundProductById();
        }
    }
}
