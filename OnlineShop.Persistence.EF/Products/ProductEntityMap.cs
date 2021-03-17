﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Persistence.EF.Products
{
    class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.ToTable("Products");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id)
            .IsRequired().ValueGeneratedOnAdd();

            _.Property(_ => _.ProductCategoryId);

            _.Property(_ => _.Title).IsRequired().HasMaxLength(100);

            _.Property(_ => _.Code).IsRequired().HasMaxLength(10);

            _.Property(_ => _.MinimumStack).IsRequired();

            _.HasMany(_ => _.InvoiceItems)
            .WithOne(_ => _.Product)
            .HasForeignKey(_ => _.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

            _.HasMany(_ => _.StoreRooms)
            .WithOne(_ => _.Product)
            .HasForeignKey(_ => _.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        }

    }
}