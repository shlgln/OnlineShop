﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _dataContext;
        public EFProductRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Product product)
        {
            _dataContext.Add(product);
        }

        public async Task<bool> IsDuplicateProductCode(string code)
        {
            return await _dataContext.Products.AnyAsync(_ => _.Code == code);
        }

        public async Task<bool> IsDuplicateProductTitleInCategory(string title, int productCategoryId)
        {
            return await _dataContext.Products.AnyAsync(_ => _.Title == title && _.ProductCategoryId == productCategoryId);
        }
    }
}