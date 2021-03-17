﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.SaleInvoiceItems
{
    class SaleInvoiceItemEntityMap : IEntityTypeConfiguration<SaleInvoiceItem>
    {
        public void Configure(EntityTypeBuilder<SaleInvoiceItem> _)
        {
            _.ToTable("SaleInvoiceItems");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).IsRequired()
            .ValueGeneratedOnAdd();

            _.Property(_ => _.SaleInvoiceId);

            _.Property(_ => _.ProductId);

            _.Property(_ => _.ProductCount).IsRequired();

            _.Property(_ => _.Price).IsRequired();
        }
    }
}
