using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.AccountingDocuments.Contracts;
using OnlineShop.Services.AccountingDocuments.Exceptions;
using OnlineShop.Services.ParchaseInvoices.Exceptions;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.SaleInvoiceItems.Exceptions;
using OnlineShop.Services.SaleInvoices.Contracts;
using OnlineShop.Services.StoreRooms.Contracs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.SaleInvoices
{
    public class SaleInvoiceAppService : SaleInvoiceService
    {
        private readonly SaleInvoiceRepository _repository;
        private readonly ProductRepository _productRepository;
        private readonly StoreRoomRepository _storeRoomRepository;
        private readonly AccountingDocumentRepository _accountingDocumentRepository;
        private readonly UnitOfWork _unitOfWork;

        public SaleInvoiceAppService(SaleInvoiceRepository repository,
            ProductRepository productRepository, 
            StoreRoomRepository storeRoomRepository,
            AccountingDocumentRepository accountingDocumentRepository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _productRepository = productRepository;
            _storeRoomRepository = storeRoomRepository;
            _accountingDocumentRepository = accountingDocumentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Register(RegisterSaleInvoiceDto dto)
        {
            decimal totalAmount = 0;

            await CheckIsExistInvoiceNumber(dto.Number);

            var saleInvoceItems = new List<SaleInvoiceItem>();
            var saleInvoice = new SaleInvoice()
            {
                DateRegistration = DateTime.Now,
                CustomerName = dto.CustomerName,
                Number = dto.Number,
            };

            foreach (var item in dto.SaleInvoiceItems)
            {
                await CheckIsExistProduct(item.ProductId);

                await CheckCountMoreStock(item.ProductId, item.ProductCount);

                saleInvoceItems.Add(new SaleInvoiceItem
                {
                    ProductId = item.ProductId,
                    ProductCount = item.ProductCount,
                    Price = item.Price,
                    SaleInvoiceId = saleInvoice.Id,

                });
                totalAmount = totalAmount + (item.ProductCount * item.Price);

                await ReduceStockProductFromStoreRoom(item.ProductId, item.ProductCount);
            }
            saleInvoice.saleInvoiceItems.AddRange(saleInvoceItems);

            await CheckIsDuplicatedAccountingNumber(dto.accountingDocumentDto.Number);

            var accountingDocument = new AccountingDocument
            {
                DateRegistration = DateTime.Now,
                TotalAmount = totalAmount,
                SaleInvoiceId = saleInvoice.Id,
                Number = dto.accountingDocumentDto.Number,
                SaleInvoiceNumber = saleInvoice.Number
            };
            saleInvoice.AccountingDocuments.Add(accountingDocument);

            _repository.Add(saleInvoice);

            await _unitOfWork.Complete();

            return saleInvoice.Id;
        }

        private async Task CheckIsExistInvoiceNumber(string number)
        {
            if (await _repository.IsDuplicatedInvoiceNumber(number))
            {
                throw new DuplicateInvoiceNumberException();
            }
        }
        private async Task CheckIsExistProduct(int id)
        {
            var product = await _productRepository.FindProductById(id);

            if (product == null)
                throw new NotFoundProductById();
        }

        private async Task CheckCountMoreStock(int productId, int count)
        {
            var productInStore = await _storeRoomRepository.FindByProductId(productId);

            if (productInStore.Stock < count || productInStore.Stock == 0)
                throw new StoreInventoryLessThanSaleCountException();
        }

        private async Task ReduceStockProductFromStoreRoom(int productId, int count)
        {
            var productInStore = await _storeRoomRepository.FindByProductId(productId);

            productInStore.Stock -= count;
        }
        private async Task CheckIsDuplicatedAccountingNumber(string number)
        {
            if (await _accountingDocumentRepository.IsDuplicatedAccountingNumber(number))
                throw new DuplicatedAccountingDocumnetNumberException();
        }

    }
}
